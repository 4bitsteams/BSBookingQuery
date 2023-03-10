using BSBookingQuery.DAL.IRepository;

namespace BSBookingQuery.DAL.UnitOfWork
{
    public interface IUnitOfWork /*: IDisposable*/
    {
        ILocationRepository LocationRepository();
        IRatingRepository RatingRepository();
        IHotelRepository HotelRepository();
        ICommentRepository CommentRepository();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
