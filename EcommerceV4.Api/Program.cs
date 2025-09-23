using EcommerceV4.Application.Common.Interfaces;
using EcommerceV4.Application.Features.Companies.Commands.CreateCompany;
using EcommerceV4.Application.Features.Products.Externals;
using EcommerceV4.Application.Features.Stories.Commands.CreateStore;
using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using EcommerceV4.Domain.Aggregates.CompanyAggregate.Interfaces;
using EcommerceV4.Domain.Aggregates.ProductAggregate;
using EcommerceV4.Domain.Aggregates.StoreAggregate;
using EcommerceV4.Domain.Aggregates.StoreAggregate.Interfaces;
using EcommerceV4.Domain.Repositories;
using EcommerceV4.Infrastructure.Persistence;
using EcommerceV4.Infrastructure.Repositories;
using EcommerceV4.Infrastructure.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<EcommerceDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
  
//Validator
builder.Services.AddScoped<IValidator<CreateCompanyCommand>, CreateCompanyCommandValidator>();
builder.Services.AddScoped<IValidator<CreateStoreCommand>, CreateStoreCommandValidator>();

//unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Repository
builder.Services.AddScoped<IRepository<Company>, CompanyRepository>();
builder.Services.AddScoped<IRepository<Store>, StoreRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<ProductVariant>, ProductVariantRepository>();

//infrastructure service
builder.Services.AddScoped<ICompanyChecker, CompanyChecker>();
builder.Services.AddScoped<IStoreChecker, StoreChecker>();


//Domain services
builder.Services.AddScoped<ICompanyDomainService, CompanyDomainService>();
builder.Services.AddScoped<IStoreDomainService, StoreDomainService>();

//External
builder.Services.AddScoped<IExternalApi<List<ProductExternal>>, GetProductExternalHandler>();

//MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CreateCompanyCommandHandler).Assembly);
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
