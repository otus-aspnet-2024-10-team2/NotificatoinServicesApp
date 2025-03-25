using Core.Entity;
using Infrastructure.Repositories.Implementations;
using Microsoft.OpenApi.Models;
using Services.Abstractions;
using Services.Implementations;
using Services.Repositories;
using WebApi.Extensions;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();

        // builder.Services.AddDependecyGroup();
        builder.Services.AddControllers();
        builder.Services.AddTransient<INotificationService, NotificationService>();
        builder.Services.AddTransient<INotificationRepository, NotificationRepository>();
        
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo{Title = "NotificationApp", Version = "v1"});
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