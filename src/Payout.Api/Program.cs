using Microsoft.EntityFrameworkCore;
using Payout.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Controllers (so we can grow cleanly)
builder.Services.AddControllers();

// OpenAPI (built-in .NET OpenAPI support)
builder.Services.AddOpenApi();

// EF Core + SQLite
var connStr = builder.Configuration.GetConnectionString("PayoutDb");
if (string.IsNullOrWhiteSpace(connStr))
    throw new InvalidOperationException("Missing ConnectionStrings:PayoutDb");

builder.Services.AddDbContext<PayoutDbContext>(options =>
{
    options.UseSqlite(connStr);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Generates /openapi/v1.json
    app.MapOpenApi();

    // Nice interactive UI at /swagger (uses the built-in OpenAPI doc)
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Payout API v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
