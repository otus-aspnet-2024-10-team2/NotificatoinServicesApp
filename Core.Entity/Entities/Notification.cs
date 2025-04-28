using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity.Base;
using Core.Entity.Exceptions;
using Core.Entity.Helpers;

namespace Core.Entity;

public class Notification : IEntity<Guid>
{
    /// <summary>
    /// Идинтификатор
    /// </summary>
    [Column("Id")]
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    [Column("Title")]
    public string Title { get; set; }
    /// <summary>
    /// Текст уведомления
    /// </summary>
    [Column("Description")]
    public string Description { get; set; }
    /// <summary>
    /// Дата создания, по умолчанию - текущая дата
    /// </summary>
    [Column("DateCreated", TypeName = "date")]
    public DateTime DateCreated { get; set; } = DateTime.Now;
    /// <summary>
    /// Дата рассылки
    /// </summary>
    [Column("DateSended", TypeName = "date")]
    public DateTime? DateSended { get; set; }
    /// <summary>
    /// Признак рассылки
    /// </summary>
    [Column("Sending")]
    public bool Sending { get; set; } = false;
    /// <summary>
    /// Тип рассылки
    /// </summary>
    [Column("TypeNotification")]
    public NotificationType TypeNotification { get; set; }

    /// <summary>
    /// Признак удаления уведомления
    /// </summary>
    public bool IsDeleted { get; set; }
}