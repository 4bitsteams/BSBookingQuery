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

        public Task<bool> Add(LocationCreateViewModel entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<LocationViewModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<LocationViewModel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.Location.GetAsync(id);
            var _map = _mapper.Map<Location, LocationViewModel>(result);
            return _map;
        }

        public Task<bool> Update(LocationUpdateViewModel entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
