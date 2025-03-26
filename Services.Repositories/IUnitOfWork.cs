﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public interface IUnitOfWork
    {
        INotificationRepository NotificationRepository { get; }

        Task SaveChangesAsync();
    }
}
