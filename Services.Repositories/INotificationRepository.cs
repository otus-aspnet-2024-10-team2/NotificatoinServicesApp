namespace Services.Repositories;

public interface INotificationRepository
{
    /// <summary>
    /// Получить произвольный ИД уведомления
    /// </summary>
    /// <returns></returns>
    Task<int> GetDefaultIdAsync();
}