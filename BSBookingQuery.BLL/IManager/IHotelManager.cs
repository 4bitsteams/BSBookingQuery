using BSBookingQuery.ViewModel.ViewModel.Hotel;

namespace BSBookingQuery.BLL.IManager
{
    public interface IHotelManager
    {
        Task<List<HotelViewModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<HotelViewModel> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> Add(HotelCreateViewModel entity, CancellationToken cancellationToken = default);
        Task<bool> Update(HotelUpdateViewModel entity, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
