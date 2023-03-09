using AutoMapper;
using BSBookingQuery.BLL.IManager;
using BSBookingQuery.DAL.UnitOfWork;
using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel;

namespace BSBookingQuery.BLL.Manager
{
    public class LocationManager : ILocationManager
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        public LocationManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Add(LocationCreateViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LocationViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<LocationViewModel> GetAsync(int id)
        {
            var result = await this.unitOfWork.Location.GetAsync(id);
            var pp = _mapper.Map<Location, LocationViewModel>(result);
            return pp;
        }

        public Task<bool> Update(LocationUpdateViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
