using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel.Hotel;

namespace BSBookingQuery.DAL.IRepository
{

    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<List<Hotel>> Search(SearchModel searchModel, CancellationToken cancellationToken = default);
    }
}
