using Core.Entity.Base;

namespace Core.Entity.Entities;
/// <summary>
/// Сущность, отвечающая за пользователей, которым надо рассылать уведомления
/// </summary>
public class User : IEntity<int>
{
    /// <summary>
    /// Ид пользователя
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    public string? SecondName { get; set; }
    /// <summary>
    /// Город
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; set; }
    /// <summary>
    /// Е-Mail
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// Как получать рассылку
    /// </summary>
    public IEnumerable<NotificationType> NotificationTypes { get; set; }
    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime DateCreated { get; set; }
    /// <summary>
    /// Категория пользователя
    /// </summary>
    public UserType UserType { get; set; }
    /// <summary>
    /// Признак активности пользователя
    /// </summary>
    public bool IsActiveUser { get; set; }
}