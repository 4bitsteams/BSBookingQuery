using BSBookingQuery.ViewModel.ViewModel.Rating;

namespace BSBookingQuery.BLL.IManager
{
    public interface IRatingManager
    {
        Task<List<RatingViewModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<RatingViewModel> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> Add(RatingCreateViewModel entity, CancellationToken cancellationToken = default);
        Task<bool> Update(RatingUpdateViewModel entity, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
