using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.Entity.Models;

namespace BSBookingQuery.DAL.Repository
{
    class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(BSBookingQueryContext context) : base(context) { }

    }
}
