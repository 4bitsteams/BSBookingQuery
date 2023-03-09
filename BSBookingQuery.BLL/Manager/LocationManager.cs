using AutoMapper;
using BSBookingQuery.BLL.IManager;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel;

namespace BSBookingQuery.BLL.Manager
{
    public class LocationManager : ILocationManager
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository locationRepository;
        public LocationManager(IMapper mapper, ILocationRepository locationRepository)
        {
            _mapper = mapper;
            this.locationRepository = locationRepository;
        }

        public async Task<bool> Add(LocationCreateViewModel entity, CancellationToken cancellationToken = default)
        {
            var _map = _mapper.Map<LocationCreateViewModel,Location>(entity);
            _map.CreatedBy = 1; //TODO it is come from Uer Session
            _map.CreatedDate = DateTime.Now;
            _map.IsActive = true;
            _map.IsDeleted = false;
            return await this.locationRepository.AddEntity(_map, cancellationToken);
        }

        public async Task<bool> Update(LocationUpdateViewModel entity, CancellationToken cancellationToken = default)
        {
            var _map = _mapper.Map<LocationUpdateViewModel, Location>(entity);
            _map.UpdatedBy= 1; //TODO it is come from Uer Session
            _map.UpdatedDate = DateTime.Now;
            return await this.locationRepository.UpdateEntity(_map, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            return await this.locationRepository.DeleteEntity(id,cancellationToken);
        }

        public async Task<List<LocationViewModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await this.locationRepository.GetAllAsync(cancellationToken);
            var _map = _mapper.Map<List<Location>, List<LocationViewModel>>(result);
            return _map;
        }

        public async Task<LocationViewModel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.locationRepository.GetAsync(id, cancellationToken);
            var _map = _mapper.Map<Location, LocationViewModel>(result);
            return _map;
        }
    
    }
}
