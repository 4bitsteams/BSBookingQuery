using BSBookingQuery.DAL.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSBookingQuery.IOC.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this
            IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BSBookingQueryContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(BSBookingQueryContext).Assembly.FullName)), ServiceLifetime.Transient);
            return services;
        }
    }
}
