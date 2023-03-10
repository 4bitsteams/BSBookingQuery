using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.DAL.Repository
{
    class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        internal static class CacheKeyDictionary
        {
            public static string RatingGetAllAsyncCacheKey => "Rating.GetAllAsync";
            public static string RatingGetAsyncCacheKey => "Rating.GetAsync";
        }
        public RatingRepository(BSBookingQueryContext context) : base(context) { }

        public override Task<List<Rating>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }
        public override async Task<Rating> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
            return result;
        }

        public override async Task<bool> AddEntity(Rating entity, CancellationToken cancellationToken = default)
        {
            //TODO Need to Check Duplicate Data
            await DbSet.AddAsync(entity, cancellationToken);
            return true;
        }
        public override async Task<bool> UpdateEntity(Rating entity, CancellationToken cancellationToken = default)
        {
            //TODO Need to Check Duplicate Data
            var original = await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == entity.Id, cancellationToken);
            if (original != null)
            {
                //DbSet.Entry<Rating>(original).CurrentValues.SetValues(entity);
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
