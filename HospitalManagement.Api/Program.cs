using HospitalManagement.Data.DbContext;
using HospitalManagement.DataAccess.Common.Interfaces;
using HospitalManagement.DataAccess.Repositories;
using HospitalManagement.Service.Common.Interfaces;
using HospitalManagement.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer("DatabaseConnection",
            providerOptions => providerOptions.EnableRetryOnFailure()));

builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

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
