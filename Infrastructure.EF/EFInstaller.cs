using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                //.UseSqlite(connectionString)
                 .UseNpgsql(connectionString)
                );

            return services;
        }
    }
}
