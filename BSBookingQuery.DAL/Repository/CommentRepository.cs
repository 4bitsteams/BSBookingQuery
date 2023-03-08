using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.Entity.Models;

namespace BSBookingQuery.DAL.Repository
{
    class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BSBookingQueryContext context) : base(context) { }

    }
}
