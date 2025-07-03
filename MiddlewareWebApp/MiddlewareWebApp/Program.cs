using MiddlewareWebApp;

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
app.UseFirstDemoMiddleware();
app.UseSecondDemoMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
