using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.Entity.Models;

namespace BSBookingQuery.DAL.Repository
{
    class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(BSBookingQueryContext context) : base(context) { }

    }
}
