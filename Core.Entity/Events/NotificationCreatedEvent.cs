using Core.Entity.Base;

namespace Core.Entity.Events;

public class NotificationCreatedEvent : IEntity<Guid>
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
}