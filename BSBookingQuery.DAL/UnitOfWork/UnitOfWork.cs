using BSBookingQuery.DAL.ApplicationDbContext;
using BSBookingQuery.DAL.IRepository;
using BSBookingQuery.DAL.Repository;

namespace BSBookingQuery.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BSBookingQueryContext context;
        public ILocationRepository locationRepository { get; private set; }
        //private bool _disposed;
        public UnitOfWork(BSBookingQueryContext context)
        {
            this.context = context;
        }


        public ILocationRepository LocationRepository()
        {
            if (this.locationRepository == null)
            {
                this.locationRepository = new LocationRepository(this.context);
            }
            return this.locationRepository;
        }

        //~UnitOfWork()=>Dispose();
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed && disposing)
        //    {
        //        this.context.Dispose();
        //    }
        //    _disposed = true;
        //}


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            using var tran = await this.context.Database.BeginTransactionAsync();
            try
            {
                var result = await this.context.SaveChangesAsync(cancellationToken);
                await tran.CommitAsync();
                var d = tran.TransactionId;
                return result;
            }
            catch (Exception)
            {
                await tran.RollbackAsync();
                throw;
            }
        }
    }
}
