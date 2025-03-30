using MassTransit;
using WebApi.Extensions.RabbitExtension.Consumer;
using WebApi.Settings;

namespace WebApi.Extensions.NotificationExtensions;

public static class RmqExtension
{
    /// <summary>
    /// Инициализация rabbitamq
    /// </summary>
    /// <param name="configurator"></param>
    /// <param name="configuration"></param>
    public static void InstallRabbitMqSetting(IRabbitMqBusFactoryConfigurator configurator,
        IConfiguration configuration)
    {
        var rmqConfig = configuration.Get<ApplicationSettings>().rmqSettings;
        configurator.Host(rmqConfig.Host,
            rmqConfig.VHost,
            h =>
            {
                h.Username(rmqConfig.Login);
                h.Password(rmqConfig.Password);
            });
    }

    /// <summary>
    /// Ргистратор эндпоинта
    /// </summary>
    /// <param name="configurator"></param>
    public static void InstallRabbitMqEndpoint(IRabbitMqBusFactoryConfigurator configurator)
    {
        configurator.ReceiveEndpoint($"notification_queue", x =>
        {
             x.Consumer<EventConsumer>();
             x.UseMessageRetry(r =>
             {
                 r.Incremental(3, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
             });
             x.PrefetchCount = 1;
             x.UseConcurrencyLimit(1);
        });
    }
}