using System.Reflection;
using Core.Entity;
using Infrastructure.EF;
using Infrastructure.Repositories.Implementations;
using MassTransit;
using MassTransit.MultiBus;
using Microsoft.OpenApi.Models;
using Services.Abstractions;
using Services.Implementations;
using Services.Repositories;
using WebApi.Controllers;
using WebApi.Extensions;
using WebApi.Extensions.NotificationExtensions;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        services.AddControllers();
        //найтрока automapper'a
        services.InstallAutomapper();
        //DI
        //notifications
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        //users
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        var config = builder.Configuration;
        services.ConfigurationContext(config.GetConnectionString("SqliteConnection"));
        
        services.AddAuthorization();
        services.AddEndpointsApiExplorer();
        //Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "NotificationApp", Version = "v1" });
            var filePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            c.IncludeXmlComments(filePath);
        });

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                RmqExtension.InstallRabbitMqSetting(cfg, config);
                RmqExtension.InstallRabbitMqEndpoint(cfg);
            });
        });
        
        services.AddCors();
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
                c.RoutePrefix = "";
            });
        }
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}