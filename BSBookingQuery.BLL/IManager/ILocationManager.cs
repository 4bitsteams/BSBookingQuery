using BSBookingQuery.ViewModel.ViewModel;

namespace BSBookingQuery.BLL.IManager
{
    public interface ILocationManager
    {
        Task<LocationViewModel> GetById(int id);
        Task<IEnumerable<LocationViewModel>> GetAll();
        Task Add(CreateViewModel entity);
        Task AddRange(IEnumerable<CreateViewModel> entities);
        void Update(UpdateViewModel entity);
        void UpdateRange(IEnumerable<UpdateViewModel> entities);
        void Delete(DeleteViewModel entity);
        void DeleteRange(IEnumerable<DeleteViewModel> entities);
    }
}
