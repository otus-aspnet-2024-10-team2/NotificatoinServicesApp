using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    [Column("Id")]
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Column("Name")]
    [Required]
    public string? Name { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    public string? SecondName { get; set; }
    /// <summary>
    /// Город
    /// </summary>
    [Column("City")]
    public string City { get; set; }
    /// <summary>
    /// Номер телефона
    /// </summary>
    [Column("PhoneNumber")]
    public string PhoneNumber { get; set; }
    /// <summary>
    /// Е-Mail
    /// </summary>
    [Column("Email")]
    public string? Email { get; set; }
    /// <summary>
    /// Как получать рассылку
    /// </summary>
    [NotMapped]
    [Column("NotificationType", TypeName = "int")]
    public IEnumerable<NotificationType> NotificationTypes { get; set; }
    /// <summary>
    /// Дата создания записи
    /// </summary>
    [Column("DateCreated", TypeName = "date")]
    public DateTime DateCreated { get; set; }
    /// <summary>
    /// Категория пользователя
    /// </summary>
    [Column("UserType", TypeName = "int")]
    public UserType UserType { get; set; }
    /// <summary>
    /// Признак активности пользователя
    /// </summary>
    public bool IsActiveUser { get; set; }
}