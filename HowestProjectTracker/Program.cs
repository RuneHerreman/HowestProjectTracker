using HowestProjectTracker.Domain.Repositories;
using HowestProjectTracker.Infrastructure.Data;
using HowestProjectTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//  DATABASE
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string not found");
builder.Services.AddDbContext<SchoolContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// DI
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) => {
        document.Info = new()
        {
            Title = "Howest Project Tracker API",
            Version = "v1",
            Description = "Made for the .NET course at Howest"
        };
        return Task.CompletedTask;
    });
});


var app = builder.Build();

app.MapScalarApiReference(options =>
{
    options.Title = "Howest Project Tracker API";
    options.Theme = ScalarTheme.Purple;
});

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // Exposeert Scalar UI op /scalar/v1 [7]
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
