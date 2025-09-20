using EcommerceV4.Application.Features.Companies.Commands.CreateCompany;
using EcommerceV4.Domain.Aggregates.CompanyAggregate.Services;
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

//unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//infrastructure service
builder.Services.AddScoped<ICompanyChecker, CompanyChecker>();


//MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
