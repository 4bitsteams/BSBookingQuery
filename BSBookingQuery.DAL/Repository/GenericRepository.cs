using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BSBookingQuery.DAL.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly BSBookingQueryContext _dbContext;
        public GenericRepository(BSBookingQueryContext context)
        {
            this._dbContext = context;
        }

        public async Task<T> GetById(int id)
        {
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entitys)
        {
            _dbContext.Set<T>().RemoveRange(entitys);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entitys)
        {
            _dbContext.Set<T>().UpdateRange(entitys);
        }
    }
}
