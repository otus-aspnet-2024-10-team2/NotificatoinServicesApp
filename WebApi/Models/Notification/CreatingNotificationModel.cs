using Core.Entity;

namespace WebApi.Models.Notification;

public class CreatingNotificationModel
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
}