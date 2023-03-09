using AutoMapper;
using BSBookingQuery.BLL.IManager;
using BSBookingQuery.DAL.UnitOfWork;
using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel;

namespace BSBookingQuery.BLL.Manager
{
    public class LocationManager : ILocationManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;
        public LocationManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(LocationCreateViewModel entity, CancellationToken cancellationToken = default)
        {
            var _map = _mapper.Map<LocationCreateViewModel, Location>(entity);
            _map.CreatedBy = 1; //TODO it is come from Uer Session
            _map.CreatedDate = DateTime.Now;
            _map.IsActive = true;
            _map.IsDeleted = false;
            var result = await this.unitOfWork.LocationRepository().AddEntity(_map, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Update(LocationUpdateViewModel entity, CancellationToken cancellationToken = default)
        {
            var _map = _mapper.Map<LocationUpdateViewModel, Location>(entity);
            _map.UpdatedBy = 1; //TODO it is come from Uer Session
            _map.UpdatedDate = DateTime.Now;
            var result = await this.unitOfWork.LocationRepository().UpdateEntity(_map, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.LocationRepository().DeleteEntity(id, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<List<LocationViewModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.LocationRepository().GetAllAsync(cancellationToken);
            var _map = _mapper.Map<List<Location>, List<LocationViewModel>>(result);
            return _map;
        }

        public async Task<LocationViewModel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.LocationRepository().GetAsync(id, cancellationToken);
            var _map = _mapper.Map<Location, LocationViewModel>(result);
            return _map;
        }

    }
}
