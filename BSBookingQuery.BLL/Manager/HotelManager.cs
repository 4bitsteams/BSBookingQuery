using AutoMapper;
using BSBookingQuery.BLL.IManager;
using BSBookingQuery.DAL.UnitOfWork;
using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel.Hotel;

namespace BSBookingQuery.BLL.Manager
{
    public class HotelManager : IHotelManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;
        public HotelManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(HotelCreateViewModel entity, CancellationToken cancellationToken = default)
        {
            var _map = _mapper.Map<HotelCreateViewModel, Hotel>(entity);
            _map.CreatedBy = 1; //TODO it is come from Uer Session
            _map.CreatedDate = DateTime.Now;
            _map.IsActive = true;
            _map.IsDeleted = false;
            var result = await this.unitOfWork.HotelRepository().AddEntity(_map, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Update(HotelUpdateViewModel entity, CancellationToken cancellationToken = default)
        {
            var _map = _mapper.Map<HotelUpdateViewModel, Hotel>(entity);
            _map.UpdatedBy = 1; //TODO it is come from Uer Session
            _map.UpdatedDate = DateTime.Now;
            var result = await this.unitOfWork.HotelRepository().UpdateEntity(_map, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.HotelRepository().DeleteEntity(id, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<List<HotelViewModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.HotelRepository().GetAllAsync(cancellationToken);
            var _map = _mapper.Map<List<Hotel>, List<HotelViewModel>>(result);
            return _map;
        }

        public async Task<HotelViewModel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.HotelRepository().GetAsync(id, cancellationToken);
            var _map = _mapper.Map<Hotel, HotelViewModel>(result);
            return _map;
        }

    }
}
