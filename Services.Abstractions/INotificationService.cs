using Services.Contracts.Notification;
using Services.Contracts.NotificationDto;

namespace Services.Abstractions;

public interface INotificationService
{
    /// <summary>
    /// Получить произвольный ID уведомления
    /// </summary>
    /// <returns></returns>
    Task<Guid> GetDefaultIdAsync();

    /// <summary>
    /// Получить уведомление по ID
    /// </summary>
    /// <param name="id">GUID уведомления</param>
    /// <returns></returns>
    Task<NotificationDto> GetNotificationByIdAsync(Guid id);

    /// <summary>
    /// Создать новое уведомление
    /// </summary>
    /// <param name="createNotificationDto">ДТО создаваемого уведомления</param>
    /// <returns>GUID уведомления</returns>
    Task<Guid> CreateNewNotificationAsync(CreateNotificationDto createNotificationDto);

    /// <summary>
    /// Обновить уведомление
    /// </summary>
    /// <param name="id">GUID Уведомления</param>
    /// <param name="updateNotificationDto">DTO уведомления</param>
    /// <returns></returns>
    Task UpdateNotificationAsync(Guid id, UpdateNotificationDto updateNotificationDto);
}