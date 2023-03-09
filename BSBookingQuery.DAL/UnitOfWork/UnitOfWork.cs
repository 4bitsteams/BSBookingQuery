using BSBookingQuery.DAL.ApplicationDbContext;

namespace BSBookingQuery.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BSBookingQueryContext context;
        private bool _disposed;
        public UnitOfWork(BSBookingQueryContext context)
        {
            this.context = context;
        }

        //~UnitOfWork()=>Dispose();
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                this.context.Dispose();
            }
            _disposed = true;
        }


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            using var tran = await context.Database.BeginTransactionAsync();
            try
            {
                var result = await context.SaveChangesAsync(cancellationToken);
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
