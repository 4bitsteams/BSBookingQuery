using BSBookingQuery.BLL.IManager;
using BSBookingQuery.DAL.UnitOfWork;
using BSBookingQuery.ViewModel.ViewModel;

namespace BSBookingQuery.BLL.Manager
{
    public class LocationManager : ILocationManager
    {
        private readonly IUnitOfWork unitOfWork;
        public LocationManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task Add(CreateViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRange(IEnumerable<CreateViewModel> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(DeleteViewModel entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<DeleteViewModel> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LocationViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<LocationViewModel> GetById(int id)
        {
            LocationViewModel locationViewModel = new LocationViewModel();
            var result=await unitOfWork.Location.GetById(id);
            return locationViewModel;
        }

        public void Update(UpdateViewModel entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<UpdateViewModel> entities)
        {
            throw new NotImplementedException();
        }
    }
}
