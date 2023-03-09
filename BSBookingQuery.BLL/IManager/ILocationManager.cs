using BSBookingQuery.ViewModel.ViewModel;

namespace BSBookingQuery.BLL.IManager
{
    public interface ILocationManager
    {
        Task<List<LocationViewModel>> GetAllAsync();
        Task<LocationViewModel> GetAsync(int id);
        Task<bool> Add(LocationCreateViewModel entity);
        Task<bool> Update(LocationUpdateViewModel entity);
        Task<bool> Delete(int id);
    }
}
