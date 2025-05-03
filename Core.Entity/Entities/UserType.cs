namespace Core.Entity.Entities;
/// <summary>
/// Тип юзера
/// </summary>
public enum UserType
{
    /// <summary>
    /// Администратор
    /// </summary>
    Administrator = 1,
    /// <summary>
    /// Волнтер
    /// </summary>
    Volunteer = 2 ,
    /// <summary>
    /// Простой участник
    /// </summary>
    Member = 3,
    /// <summary>
    /// Владелец/ инициатор объявления
    /// </summary>
    Owner = 4,
    /// <summary>
    /// Случайный пользователь сервиса
    /// </summary>
    Nomad = 5,
    /// <summary>
    /// Новый пользователь
    /// </summary>
    NewUser = 6,
}