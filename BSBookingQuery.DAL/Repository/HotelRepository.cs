﻿using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.Entity.Models;
using BSBookingQuery.ViewModel.ViewModel.Hotel;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.DAL.Repository
{
    class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(BSBookingQueryContext context) : base(context) { }

        public override Task<List<Hotel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        public async Task<List<Hotel>> Search(SearchModel searchModel, CancellationToken cancellationToken = default)
        {
            string st = searchModel.SearchText.Trim().ToLower();
            // var query = DbSet.Include(x=>x.Rating).Include(x=>x.Location).AsQueryable(); //TODO AsQueryable with Include Not Working need to optimize
            var query = await DbSet.AsNoTracking().Include(x => x.Rating).Include(x => x.Location).Where(x => x.IsDeleted != true).ToListAsync();
            if (!string.IsNullOrEmpty(searchModel.SearchText))
            {
                var result = query.Where(x => x.Id.ToString().ToLower().Contains(st)
                 || x.Name.ToString().ToLower().Contains(st)
                 || x.Rating.Name.ToLower().Contains(st)
                 || x.Location.Name.ToLower().StartsWith(st));
                return result.ToList();
            }
            return query;
        }
        public override async Task<Hotel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
            return result;
        }

        public override async Task<bool> AddEntity(Hotel entity, CancellationToken cancellationToken = default)
        {
            //TODO Need to Check Duplicate Data
            await DbSet.AddAsync(entity, cancellationToken);
            return true;
        }
        public override async Task<bool> UpdateEntity(Hotel entity, CancellationToken cancellationToken = default)
        {
            //TODO Need to Check Duplicate Data
            var original = await DbSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == entity.Id, cancellationToken);
            if (original != null)
            {
                //DbSet.Entry<Hotel>(original).CurrentValues.SetValues(entity);
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
