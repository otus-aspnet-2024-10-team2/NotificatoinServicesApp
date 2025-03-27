using Services.Contracts.NotificationDto;

namespace Services.Abstractions;

public interface INotificationService
{
    /// <summary>
    /// Получить произвольный ID уведомления
    /// </summary>
    /// <returns></returns>
    Task<Guid> GetDefaultIdAsync();
    
}