using BSBookingQuery.DAL.IRepository;

namespace BSBookingQuery.DAL.UnitOfWork
{
    public interface IUnitOfWork /*: IDisposable*/
    {
        ILocationRepository LocationRepository();
        IRatingRepository RatingRepository();
        IHotelRepository HotelRepository();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
