﻿using Core.Entity;
using Core.Entity.Entities;

namespace Services.Contracts.Notification;

public class SendNotificationDto
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
    
    public NotificationStatus Status { get; set; }
}