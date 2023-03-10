using BSBookingQuery.DAL.IRepository;

namespace BSBookingQuery.DAL.UnitOfWork
{
    public interface IUnitOfWork /*: IDisposable*/
    {
        ILocationRepository LocationRepository();
        IRatingRepository RatingRepository();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
