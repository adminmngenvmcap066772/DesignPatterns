using MiddlewareWebApp;

// This example demonstrates how to use custom middleware in an ASP.NET Core pipeline.
// The middleware could be used in a financial context for logging, auditing, or enforcing business rules on financial APIs.
// For example, you might want to log all requests to a budget management endpoint or check user permissions before processing a transaction.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Add demo middleware to show passing calls from one to another
// In a finance scenario, these could be used for logging or validating financial transactions.
app.UseFirstDemoMiddleware(); // e.g., log request details for auditing
app.UseSecondDemoMiddleware(); // e.g., check user permissions or validate transaction data

app.UseAuthorization();

app.MapControllers();

app.Run();
