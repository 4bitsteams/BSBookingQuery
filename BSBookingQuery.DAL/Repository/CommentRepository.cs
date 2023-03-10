using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.DAL.Repository
{
    class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BSBookingQueryContext context) : base(context) { }

        public override Task<List<Comment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }
        public override async Task<Comment> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
            return result;
        }

        public override async Task<bool> AddEntity(Comment entity, CancellationToken cancellationToken = default)
        {
            //TODO Need to Check Duplicate Data
            await DbSet.AddAsync(entity, cancellationToken);
            return true;
        }
        public override async Task<bool> UpdateEntity(Comment entity, CancellationToken cancellationToken = default)
        {
            //TODO Need to Check Duplicate Data
            var original = await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == entity.Id, cancellationToken);
            if (original != null)
            {
                //DbSet.Entry<Comment>(original).CurrentValues.SetValues(entity);
                DbSet.Update(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override async Task<bool> DeleteEntity(int id, CancellationToken cancellationToken = default)
        {
            //TODO We Cam Use Soft Delete Also By IsDelete flag
            var existdata = await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
            if (existdata != null)
            {
                DbSet.Remove(existdata);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
