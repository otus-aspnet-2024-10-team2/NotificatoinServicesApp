using Infrastructure.Messaging.MessageContracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using Services.Abstractions;

namespace Infrastructure.Messaging.Consumers;

public class NotificationFileConsumer  : IConsumer<NotificationFileMessage>
{
    private readonly ILogger<NotificationFileConsumer> _logger;
    private readonly INotificationService _notificationService;

    public NotificationFileConsumer(ILogger<NotificationFileConsumer> logger,
        INotificationService notificationService)
    {
        _logger = logger;
        _notificationService = notificationService;
    }
    public async Task Consume(ConsumeContext<NotificationFileMessage> context)
    {
        var msg = context.Message;
        _logger.LogInformation($"Received notification file message: {msg.FilePath}");
    }
}