namespace BasedProject.DataAccess.Infrastructure.BaseRepositories
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();  
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
