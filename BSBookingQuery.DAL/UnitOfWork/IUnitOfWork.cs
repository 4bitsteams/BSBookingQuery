using BSBookingQuery.DAL.IRepository;

namespace BSBookingQuery.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IHotelRepository Hotel
        {
            get;
        }
        ICommentRepository Comment
        {
            get;
        }
        ILocationRepository Location
        {
            get;
        }

        IRatingRepository Rating
        {
            get;
        }
        int Save();
    }
}
