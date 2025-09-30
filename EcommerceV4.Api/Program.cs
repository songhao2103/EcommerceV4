using EcommerceV4.Application.Common.Interfaces;
using EcommerceV4.Application.DTOs;
using EcommerceV4.Application.Features.Companies.Commands.CreateCompany;
using EcommerceV4.Application.Features.Products.Externals;
using EcommerceV4.Application.Features.Stories.Commands.CreateStore;
using EcommerceV4.Application.Features.Users.Commands.RegisterUser;
using EcommerceV4.Domain.Aggregates.CartAggregate;
using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using EcommerceV4.Domain.Aggregates.CompanyAggregate.Interfaces;
using EcommerceV4.Domain.Aggregates.ProductAggregate;
using EcommerceV4.Domain.Aggregates.ProductAggregate.Interfaces;
using EcommerceV4.Domain.Aggregates.RefetchTokenAggregate;
using EcommerceV4.Domain.Aggregates.StoreAggregate;
using EcommerceV4.Domain.Aggregates.StoreAggregate.Interfaces;
using EcommerceV4.Domain.Aggregates.UserAggregate;
using EcommerceV4.Domain.Aggregates.UserAggregate.Interfaces;
using EcommerceV4.Domain.Common.Interfaces;
using EcommerceV4.Domain.Repositories;
using EcommerceV4.Infrastructure.Persistence;
using EcommerceV4.Infrastructure.Repositories;
using EcommerceV4.Infrastructure.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<EcommerceDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Cấu hình JWT
var jwtSetting = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSetting["Key"]);

builder.Services.AddAuthentication(option =>
{
    //Kích hoạt authentication subsystem của ASP.NET Core và config các default scheme
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    //Đặt scheme mặc định khi framework cần authenticate.
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSetting["Issuer"],
        ValidAudience = jwtSetting["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero // bỏ delay mặc định 5 phút
    };
});



//Validator
builder.Services.AddScoped<IValidator<CreateCompanyCommand>, CreateCompanyCommandValidator>();
builder.Services.AddScoped<IValidator<CreateStoreCommand>, CreateStoreCommandValidator>();
builder.Services.AddScoped<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();

//unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Repository
builder.Services.AddScoped<IRepository<Company>, CompanyRepository>();
builder.Services.AddScoped<IRepository<Store>, StoreRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<ProductVariant>, ProductVariantRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<RefetchToken>, RefetchTokenRepository>();
builder.Services.AddScoped<IRepository<Cart>, CartRepository>();

//infrastructure service
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddScoped<ICompanyChecker, CompanyChecker>();
builder.Services.AddScoped<IStoreChecker, StoreChecker>();
builder.Services.AddScoped<IUserChecker, UserChecker>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtService, JwtService>();


//Domain services
builder.Services.AddScoped<ICompanyDomainService, CompanyDomainService>();
builder.Services.AddScoped<IStoreDomainService, StoreDomainService>();
builder.Services.AddScoped<IUserDomainService, UserDomainService>();
builder.Services.AddScoped<IProductDomainService, ProductDomainService>();

//External
builder.Services.AddScoped<IExternalApi<List<ProductExternal>>, GetProductExternalHandler>();
builder.Services.AddScoped<IExternalAuthService<GoogleJsonWebSignaturePayload>, GoogleAuthService>();

//MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CreateCompanyCommandHandler).Assembly);
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Thêm security definition cho JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhập JWT token vào đây. Ví dụ: Bearer {your token}"
    });

    // Thêm security requirement (global)
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173") // thay bằng origin FE thật
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<GlobalExceptionHandlerMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
