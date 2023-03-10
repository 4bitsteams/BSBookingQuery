using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel.Hotel;

namespace BSBookingQuery.DAL.IRepository
{

    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetCommentByHotelIdAsync(SearchModel searchModel, CancellationToken cancellationToken = default);
    }
}
