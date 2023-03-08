using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.DAL.Repository;

namespace BSBookingQuery.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BSBookingQueryContext context;
        public UnitOfWork(BSBookingQueryContext context)
        {
            this.context = context;
            Hotel = new HotelRepository(this.context);
            Comment = new CommentRepository(this.context);
            Location = new LocationRepository(this.context);
            Rating = new RatingRepository(this.context);
        }
        public IHotelRepository Hotel
        {
            get;
        }
        public ICommentRepository Comment
        {
            get;
        }
        public ILocationRepository Location
        {
            get;
        }

        public IRatingRepository Rating
        {
            get;
        }
        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
