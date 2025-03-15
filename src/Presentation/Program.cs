using Microsoft.OpenApi.Models;
using DotNetEnv;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
Env.Load();
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TCCD", Version = "v1", Description = "TCCD Website APIs" });

    c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "TCCD.Backend.xml"));
    c.EnableAnnotations();
});

// Configure Database Connection
var connectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION")!;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.ConfigureApplicationServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GOE API V1");
        c.RoutePrefix = "swagger";
    });
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
