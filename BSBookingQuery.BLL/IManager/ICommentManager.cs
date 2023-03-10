using BSBookingQuery.ViewModel.ViewModel.Comment;

namespace BSBookingQuery.BLL.IManager
{
    public interface ICommentManager
    {
        Task<List<CommentViewModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CommentViewModel> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> Add(CommentCreateViewModel entity, CancellationToken cancellationToken = default);
        Task<bool> Update(CommentUpdateViewModel entity, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
