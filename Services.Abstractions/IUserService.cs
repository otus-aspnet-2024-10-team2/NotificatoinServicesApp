using Services.Contracts.Users;

namespace Services.Abstractions;

public interface IUserService
{
    Task<int> GetRandomUserId();
    
    /// <summary>
    /// Получить информацию по пользователю
    /// </summary>
    /// <param name="id">Ид пользователя</param>
    /// <returns>DTO пользователя</returns>
    Task<UserDto> GetUserByIdAsync(int id);

    /// <summary>
    /// Создать нового пользователя в бд
    /// </summary>
    /// <param name="userId">Ид пользователя</param>
    /// <param name="createUserDto">ДТО нового пользователя</param>
    /// <returns>ИД записи в БД пользователя</returns>
    Task<int> CreateNewUserAsync(int userId, CreateUserDto createUserDto);

    /// <summary>
    /// Обновить информацию по пользователю
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="updateUserDto"></param>
    /// <returns></returns>
    Task UpdateUserAsync(int userId, UpdateUserDto updateUserDto);

    /// <summary>
    /// Удалить пользоваетеля
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task DeleteUser(int userId);
}