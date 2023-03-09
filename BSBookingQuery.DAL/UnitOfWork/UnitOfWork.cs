using BSBookingQuery.DAL.ApplicationDbContext;

namespace BSBookingQuery.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BSBookingQueryContext context;
        //private bool _disposed;
        public UnitOfWork(BSBookingQueryContext context)
        {
            this.context = context;
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
           var result = await this.context.SaveChangesAsync(cancellationToken);
           return result;
        }
    }
}
