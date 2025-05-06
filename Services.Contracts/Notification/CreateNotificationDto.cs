using System.ComponentModel.DataAnnotations;
using Core.Entity;
using Core.Entity.Base;
using Core.Entity.Entities;

namespace Services.Contracts.Notification;
/// <summary>
/// ДТО для создания уведомления
/// </summary>
public class CreateNotificationDto : IEntity<Guid>
{
    /// <summary>
    /// Идинтификатор
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    // [Required(ErrorMessage = "Не указан заголовок уведомления")]
    public string Title { get; set; }
    /// <summary>
    /// Текст уведомления
    /// </summary>
    // [Required(ErrorMessage = "Не указано описание уведомления")]
    public string Description { get; set; }
    /// <summary>
    /// Дата создания, по умолчанию - текущая дата
    /// </summary>
    public DateTime DateCreated { get; set; } = DateTime.Now;
    /// <summary>
    /// Тип рассылки
    /// </summary>
    public NotificationType TypeNotification { get; set; }
    /// <summary>
    /// Статус уведомления
    /// </summary>
    public NotificationStatus Status { get; set; }
    
    /// <summary>
    /// ФИО автора сообщения
    /// </summary>
    public string FullName { get; set; }
    
    /// <summary>
    /// Город
    /// </summary>
    public string City {get; set;}
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; set; }
}