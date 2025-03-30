using Core.Entity.MassTransit;

namespace WebApi.Settings;

public class ApplicationSettings
{
    public string ConnectionString { get; set; }
    
    public RabbitMqSettings rmqSettings { get; set; }
}