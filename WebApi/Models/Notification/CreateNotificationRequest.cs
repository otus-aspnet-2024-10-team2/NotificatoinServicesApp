namespace WebApi.Models.Notification;

public class CreateNotificationRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}