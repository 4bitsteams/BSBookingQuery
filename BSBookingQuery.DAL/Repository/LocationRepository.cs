using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.DAL.Repository
{
    class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(BSBookingQueryContext context) : base(context) { }

        public override Task<List<Location>> GetAllAsync()
        {
            return base.GetAllAsync();
        }
        public override async Task<Location> GetAsync(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);
        }

        public override async Task<bool> AddEntity(Location entity)
        {
                await DbSet.AddAsync(entity);
                return true;
        }
        public override async Task<bool> UpdateEntity(Location entity)
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

        public override async Task<bool> DeleteEntity(int id)
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
