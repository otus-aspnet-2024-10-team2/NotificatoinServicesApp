using Core.Entity;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Services.Repositories;

namespace Infrastructure.Repositories.Implementations;

public class NotificationRepository : Repository<Notification, int>, INotificationRepository
{        
    public NotificationRepository(DatabaseContext context) : base(context) {}    

    public Task<int> GetDefaultIdAsync()
    {
        Random r = new Random();
        return Task.FromResult(r.Next(10, 100));
    }

    public override Task<Notification> GetAsync(int id, CancellationToken token = default)
    {
        var query = Context.Set<Notification>().AsQueryable();
        return query.SingleOrDefaultAsync(x => x.Id == id, token);
    }


}