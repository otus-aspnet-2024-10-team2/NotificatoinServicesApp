using Core.Entity;
using Core.Entity.Entities;

namespace WebApi.Models.User;

public class UpdateUserModel
{
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
    /// Категория пользователя
    /// </summary>
    public UserType UserType { get; set; }
    /// <summary>
    /// Признак активности пользователя
    /// </summary>
    public bool IsActiveUser { get; set; }
}