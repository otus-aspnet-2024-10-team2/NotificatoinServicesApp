using Core.Entity;

namespace Services.Repositories;

public interface IUserRepository : IRepository<User, int>
{
    /// <summary>
    /// Получить произвольный ИД пользователя
    /// </summary>
    /// <returns></returns>
    Task<int> GetRandomUserId();
}