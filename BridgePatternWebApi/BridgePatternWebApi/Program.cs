using BridgePatternWebApi.Abstractions;
using BridgePatternWebApi.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register Bridge pattern abstractions and implementations for dependency injection
// To switch data sources, change the implementation here
builder.Services.AddScoped<IFinancialDataSource, DatabaseFinancialDataSource>();
builder.Services.AddScoped<IFinancialReport, MonthlyFinancialReport>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
