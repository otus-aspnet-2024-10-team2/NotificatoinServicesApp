namespace Services.Contracts.Notification;

public class NotificationEventDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
}