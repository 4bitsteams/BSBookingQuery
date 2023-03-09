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
        public LocationRepository(BSBookingQueryContext context, IUnitOfWork unitOfWork) : base(context)
        {
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
            //TODO Need to Check Duplicate Data
            await DbSet.AddAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
        public override async Task<bool> UpdateEntity(Location entity, CancellationToken cancellationToken = default)
        {
            //TODO Need to Check Duplicate Data
            var original = await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == entity.Id, cancellationToken);
            if (original != null)
            {
                //DbSet.Entry<Location>(original).CurrentValues.SetValues(entity);
                DbSet.Update(entity);
                await unitOfWork.SaveChangesAsync(cancellationToken);
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
