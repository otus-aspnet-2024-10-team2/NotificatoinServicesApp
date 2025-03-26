
using Core.Entity;

namespace Services.Repositories;

public interface INotificationRepository : IRepository<Notification, int>
{
    /// <summary>
    /// Получить произвольный ИД уведомления
    /// </summary>
    /// <returns></returns>
    Task<int> GetDefaultIdAsync();
}