using BSBookingQuery.ViewModel.ViewModel;

namespace BSBookingQuery.BLL.IManager
{
    public interface ILocationManager
    {
        Task<List<LocationViewModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<LocationViewModel> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> Add(LocationCreateViewModel entity, CancellationToken cancellationToken = default);
        Task<bool> Update(LocationUpdateViewModel entity, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
