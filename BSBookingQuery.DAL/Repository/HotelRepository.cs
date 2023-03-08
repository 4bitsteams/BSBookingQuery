using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.Entity.Models;

namespace BSBookingQuery.DAL.Repository
{
    class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(BSBookingQueryContext context) : base(context) { }

    }
}
