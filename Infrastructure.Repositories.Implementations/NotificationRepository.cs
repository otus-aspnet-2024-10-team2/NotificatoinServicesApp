using Core.Entity;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Services.Repositories;

namespace Infrastructure.Repositories.Implementations;

public class NotificationRepository : Repository<Notification, Guid>, INotificationRepository
{        
    public NotificationRepository(DatabaseContext context) : base(context) {}    

    public Task<Guid> GetDefaultIdAsync()
    {
        return Task.FromResult(Guid.NewGuid());
    }

    public override Task<Notification> GetAsync(Guid id, CancellationToken token = default)
    {
        var query = Context.Set<Notification>().AsQueryable();
        return query.SingleOrDefaultAsync(x => x.Id == id, token);
    }
    
}