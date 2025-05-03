using Core.Entity;
using Core.Entity.Entities;

namespace Services.Repositories;

public interface INotificationRepository : IRepository<Notification, Guid>
{
    /// <summary>
    /// Получить произвольный ИД уведомления
    /// </summary>
    /// <returns></returns>
    Task<Guid> GetDefaultIdAsync();
    
    Task MarkAsReadAsync(Guid id);
    
    /// <summary>
    /// Получить все уведомления из БД
    /// </summary>
    /// <param name="noTracking"></param>
    /// <returns></returns>
    Task<List<Notification>> GetAllAsync(bool noTracking = false);
}