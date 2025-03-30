using Core.Entity;

namespace Services.Repositories;

public interface INotificationRepository : IRepository<Notification, Guid>
{
    /// <summary>
    /// Получить произвольный ИД уведомления
    /// </summary>
    /// <returns></returns>
    Task<Guid> GetDefaultIdAsync();
}