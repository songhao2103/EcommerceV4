using System;
using EcommerceV4.Api.DTOs.Companies;
using EcommerceV4.Application.Interfaces;
using EcommerceV4.Application.Services;
using EcommerceV4.Domain.Repositories;
using EcommerceV4.Infrastructure.Persistence;
using EcommerceV4.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<EcommerceDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
  

// Add services to the container.
builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddScoped<IValidator<PayloadCreateCompanyDTO>, PayloadCreateCompanyDTOValidator>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
