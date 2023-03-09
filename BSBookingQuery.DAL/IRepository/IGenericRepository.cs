namespace BSBookingQuery.DAL.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> AddEntity(T entity, CancellationToken cancellationToken = default);
        Task<bool> UpdateEntity(T entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteEntity(int id, CancellationToken cancellationToken = default);

    }
}
