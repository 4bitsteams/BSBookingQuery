using AutoMapper;
using BSBookingQuery.BLL.IManager;
using BSBookingQuery.DAL.UnitOfWork;
using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel.Rating;

namespace BSBookingQuery.BLL.Manager
{
    public class RatingManager : IRatingManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;
        public RatingManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(RatingCreateViewModel entity, CancellationToken cancellationToken = default)
        {
            var _map = _mapper.Map<RatingCreateViewModel, Rating>(entity);
            _map.CreatedBy = 1; //TODO it is come from Uer Session
            _map.CreatedDate = DateTime.Now;
            _map.IsActive = true;
            _map.IsDeleted = false;
            var result = await this.unitOfWork.RatingRepository().AddEntity(_map, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Update(RatingUpdateViewModel entity, CancellationToken cancellationToken = default)
        {
            var _map = _mapper.Map<RatingUpdateViewModel, Rating>(entity);
            _map.UpdatedBy = 1; //TODO it is come from Uer Session
            _map.UpdatedDate = DateTime.Now;
            var result = await this.unitOfWork.RatingRepository().UpdateEntity(_map, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.RatingRepository().DeleteEntity(id, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<List<RatingViewModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.RatingRepository().GetAllAsync(cancellationToken);
            var _map = _mapper.Map<List<Rating>, List<RatingViewModel>>(result);
            return _map;
        }

        public async Task<RatingViewModel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.RatingRepository().GetAsync(id, cancellationToken);
            var _map = _mapper.Map<Rating, RatingViewModel>(result);
            return _map;
        }

    }
}
