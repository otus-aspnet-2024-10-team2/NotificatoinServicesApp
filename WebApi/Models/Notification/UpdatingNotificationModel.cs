using Core.Entity;
using Core.Entity.Entities;

namespace WebApi.Models.Notification;

public class UpdatingNotificationModel
{
    /// <summary>
    /// Идинтификатор
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Текст уведомления
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Дата создания, по умолчанию - текущая дата
    /// </summary>
    public DateTime DateCreated { get; set; } = DateTime.Now;
    /// <summary>
    /// Тип рассылки
    /// </summary>
    public NotificationType TypeNotification { get; set; }
    
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