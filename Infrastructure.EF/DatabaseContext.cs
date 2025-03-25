using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<Notification> Notifications { get; set; }
}