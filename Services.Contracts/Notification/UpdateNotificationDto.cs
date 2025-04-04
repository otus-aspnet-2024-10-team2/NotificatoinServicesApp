using System.ComponentModel.DataAnnotations;
using Core.Entity;

namespace Services.Contracts.Notification;

public class UpdateNotificationDto
{
    /// <summary>
    /// Идинтификатор
    /// </summary>
    [Required(ErrorMessage = "Не указан GUID уведомления")]
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    [Required(ErrorMessage = "Не указан заголовок уведомления")]
    public string Title { get; set; }
    /// <summary>
    /// Текст уведомления
    /// </summary>
    [Required(ErrorMessage = "Не указано описание уведомления")]
    public string Description { get; set; }
    /// <summary>
    /// Дата создания, по умолчанию - текущая дата
    /// </summary>
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateCreated { get; set; } = DateTime.Now;
    /// <summary>
    /// Тип рассылки
    /// </summary>
    [Required(ErrorMessage = "Отсутствует тип рассылки")]
    public NotificationType TypeNotification { get; set; }
}