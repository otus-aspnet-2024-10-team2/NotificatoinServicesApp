namespace Services.Contracts.NotificationDto;

public class NotificationDto
{
    /// <summary>
    /// Идинтификатор
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Текст уведомления
    /// </summary>
    public string Message { get; set; }
}