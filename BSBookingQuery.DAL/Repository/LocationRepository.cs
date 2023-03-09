using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.DAL.UnitOfWork;
using BSBookingQuery.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.DAL.Repository
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public LocationRepository(BSBookingQueryContext context, IUnitOfWork unitOfWork) : base(context) {
            this.unitOfWork = unitOfWork;
        }
        
        public override Task<List<Location>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }
        public override async Task<Location> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
            return result;
        }

        public override async Task<bool> AddEntity(Location entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
            return true;
        }
        public override async Task<bool> UpdateEntity(Location entity, CancellationToken cancellationToken = default)
        {
            var original = await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == entity.Id);
            if (original != null)
            {
                //DbSet.Entry<Location>(original).CurrentValues.SetValues(entity);
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
            var existdata = await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);
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
