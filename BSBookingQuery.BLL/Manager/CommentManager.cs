using AutoMapper;
using BSBookingQuery.BLL.IManager;
using BSBookingQuery.DAL.UnitOfWork;
using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel.Comment;

namespace BSBookingQuery.BLL.Manager
{
    public class CommentManager : ICommentManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;
        public CommentManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(CommentCreateViewModel entity, CancellationToken cancellationToken = default)
        {
            var _map = _mapper.Map<CommentCreateViewModel, Comment>(entity);
            _map.CreatedBy = 1; //TODO it is come from Uer Session
            _map.CreatedDate = DateTime.Now;
            _map.IsActive = true;
            _map.IsDeleted = false;
            var result = await this.unitOfWork.CommentRepository().AddEntity(_map, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Update(CommentUpdateViewModel entity, CancellationToken cancellationToken = default)
        {
            var _map = _mapper.Map<CommentUpdateViewModel, Comment>(entity);
            _map.UpdatedBy = 1; //TODO it is come from Uer Session
            _map.UpdatedDate = DateTime.Now;
            var result = await this.unitOfWork.CommentRepository().UpdateEntity(_map, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.CommentRepository().DeleteEntity(id, cancellationToken);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<List<CommentViewModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.CommentRepository().GetAllAsync(cancellationToken);
            var _map = _mapper.Map<List<Comment>, List<CommentViewModel>>(result);
            return _map;
        }

        public async Task<CommentViewModel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.unitOfWork.CommentRepository().GetAsync(id, cancellationToken);
            var _map = _mapper.Map<Comment, CommentViewModel>(result);
            return _map;
        }

    }
}
