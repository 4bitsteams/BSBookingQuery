using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.DAL.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly BSBookingQueryContext _dbContext;
        internal DbSet<T> DbSet { get; set; }
        public GenericRepository(BSBookingQueryContext context)
        {
            this._dbContext = context;
            this.DbSet = this._dbContext.Set<T>();
        }

        public virtual Task<bool> AddEntity(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteEntity(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return this.DbSet.ToListAsync();
        }

        public virtual Task<T> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateEntity(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
