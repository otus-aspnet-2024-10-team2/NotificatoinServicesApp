using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    public static class EFInstaller
    {
        public static IServiceCollection ConfigurationContext(this IServiceCollection services,
            string? connectionString)
        {
            services.AddDbContext<DatabaseContext>(optionalBuilder
                => optionalBuilder
                .UseLazyLoadingProxies()
                .UseSqlite(connectionString));

            return services;
        }
    }
}
