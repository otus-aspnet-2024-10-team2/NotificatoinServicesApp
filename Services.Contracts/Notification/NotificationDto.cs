﻿using Core.Entity;
using Core.Entity.Base;

namespace Services.Contracts.Notification;

public class NotificationDto : IEntity<Guid>
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
    /// Дата рассылки
    /// </summary>
    public DateTime? DateSended { get; set; }
    /// <summary>
    /// Признак рассылки
    /// </summary> 
    public bool Sending { get; set; } = false;
    /// <summary>
    /// Тип рассылки
    /// </summary>
    public NotificationType TypeNotification { get; set; }
}