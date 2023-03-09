using BSBookingQuery.BLL.IManager;
using BSBookingQuery.BLL.Manager;
using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.DAL.Repository;
using BSBookingQuery.DAL.UnitOfWork;
using BSBookingQuery.Mapping;
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
            services.AddTransient<ILocationManager, LocationManager>();
            services.AddAutoMapper(c => c.AddProfile<SetupMapperProfile>(), typeof(SetupMapperProfile));
            services.AddTransient<IUnitOfWork,UnitOfWork>();
            return services;
        }
    }
}
