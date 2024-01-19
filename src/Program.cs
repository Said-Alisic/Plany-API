using API.Common.Interfaces;
using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
DotNetEnv.Env.Load("../.env");

// Configure the database connection
string host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
string port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
string dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "postgresql-database";
string user = Environment.GetEnvironmentVariable("DB_USER") ?? "root";
string password = Environment.GetEnvironmentVariable("DB_PASS") ?? "password";
string connectionString =
    $"Host={host};Port={port};Database={dbName};Username={user};Password={password}";

// Add database context with the configured connection string
builder.Services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(connectionString));

// Add services and controllers to the container.
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // TODO: Add development environment configurations
    Console.WriteLine("=== API is running in Development Mode ===");
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
