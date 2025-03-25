using Microsoft.EntityFrameworkCore;
using Services.Repositories;

namespace Infrastructure.Repositories.Implementations;

public class NotificationRepository : INotificationRepository
{
    private DbContext _ctx;
    //private readonly DbSet<T> _entities;
    
    public NotificationRepository(DbContext ctx) 
    {
        _ctx = ctx;
    }

    public int GetByIdAsync(int id)
    {
        Random r = new Random();
        return r.Next(10, 100);
    }

    public Task<int> GetDefaultIdAsync()
    {
        Random r = new Random();
        return Task.FromResult(r.Next(10, 100));
    }
}