using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.OpenApi.Models;
using RainFallApi;
using RainFallApi.Configurations.Swagger;
using RainFallApi.Endpoints;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Events;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Serilog configuration
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

builder.Host.UseSerilog((hostContext, services, configuration) => {
    configuration.WriteTo.Console();
});
    

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigurationSwagger();

builder.Services.AddSingleton<IRainFallApiProvider, UKRainFallApiProvider>();

builder.Services.AddControllers()
   .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseRouting();

app.UseEndpoints(endpoint => endpoint.MapControllers());

app.Run();
