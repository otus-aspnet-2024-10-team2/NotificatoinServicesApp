using Infrastructure.EF;
using Microsoft.EntityFrameworkCore.Storage;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private INotificationRepository notificationRepository;
        private DatabaseContext _context;

        public INotificationRepository NotificationRepository => notificationRepository;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            notificationRepository = new NotificationRepository(context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
