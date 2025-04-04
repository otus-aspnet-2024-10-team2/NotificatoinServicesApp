namespace Services.Contracts.Notification;

public class NotificationPageDto
{
    /// <summary>
    /// Уведомления
    /// </summary>
    public IEnumerable<NotificationDto> NotificationsList { get; set; }  
    
    /// <summary>
    /// Дата, с которой смотреть уведомления
    /// </summary>
    public DateTime? BeginDate { get; set; }
    /// <summary>
    /// Дата, по которую смотреть уведомления
    /// </summary>
    public DateTime? EndDate { get; set; }
    /// <summary>
    /// Текущая дата
    /// </summary>
    public DateTime? CurrentDate { get; set; }
    
}