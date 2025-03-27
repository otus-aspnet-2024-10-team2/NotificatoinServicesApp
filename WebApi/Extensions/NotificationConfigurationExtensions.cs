using Infrastructure.Repositories.Implementations;
using Services.Abstractions;
using Services.Implementations;
using Services.Repositories;

namespace WebApi.Extensions;

public static class NotificationConfigurationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
            .AddTransient<INotificationService, NotificationService>()
            .AddTransient<INotificationRepository, NotificationRepository>();
        return services;
    }
}