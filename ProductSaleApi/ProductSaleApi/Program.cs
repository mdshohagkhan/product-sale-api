using Microsoft.EntityFrameworkCore;
using ProductSaleApi.Models;
using System;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("con") ?? throw new InvalidOperationException("ConnectionString is not matched"));
});
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors(policy =>
{
    policy.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod();
});
app.MapControllers();

app.Run();
