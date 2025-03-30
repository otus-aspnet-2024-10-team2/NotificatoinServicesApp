using System.Text.Json;
using Core.Entity;
using MassTransit;
using Services.Contracts.Notification;

namespace WebApi.Extensions.RabbitExtension.Consumer;

public class EventConsumer : IConsumer<MessageNotificationDto>
{
    public async Task Consume(ConsumeContext<MessageNotificationDto> context)
    {
        var jsonPayload = context.Message.message;
        var notification = JsonSerializer.Deserialize<Notification>(jsonPayload.Id);
        
    }
}