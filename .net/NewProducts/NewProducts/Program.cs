using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NewProducts.Entity.Data;
using NewProducts.Entity.Models;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductContext>(optionsAction: options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectDB")));


builder.Services.AddScoped<IOrder<User>, ProductPatternRepository>();
builder.Services.AddScoped<IOrder<Product>, ProductPatternRepository>();
builder.Services.AddScoped<IOrder<CartItem>, ProductPatternRepository>();
builder.Services.AddScoped<IOrder<Invoice>, ProductPatternRepository>();


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
