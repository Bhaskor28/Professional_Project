namespace EmployeeManagementSystem.Application.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        public IQueryable<T> Table { get; }
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        IQueryable<T> GetQueryable();


    }
}
