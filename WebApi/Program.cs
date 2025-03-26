using Core.Entity;
using Infrastructure.EF;
using Infrastructure.Repositories.Implementations;
using Microsoft.OpenApi.Models;
using Services.Abstractions;
using Services.Implementations;
using Services.Repositories;
using WebApi.Controllers;
using WebApi.Extensions;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        services.AddControllers();
        services.AddScoped<INotificationService, NotificationService>();
        services.ConfigurationContext(builder.Configuration.GetConnectionString("DefaultConnection"));
        services.AddTransient<INotificationRepository, NotificationRepository>();
        services.AddAuthorization();
        services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "NotificationApp", Version = "v1" });
        });
        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        if (!app.Environment.IsProduction())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NotificationServiceApi V1");
                c.RoutePrefix = string.Empty;
            });
        }
        app.UseRouting();
         
        app.UseAuthorization();

        app.MapControllers();
        
        app.Run();
    }
}