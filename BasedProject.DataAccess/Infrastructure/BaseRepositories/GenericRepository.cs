using BasedProject.Models.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace BasedProject.DataAccess.Infrastructure.BaseRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly BasedProjectDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(BasedProjectDbContext _dbContext)
        {
            this._dbContext = _dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task Create(T entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
