using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Context;

namespace ProductManagement.API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbSet<T> _dbset { get; set; }
        private ProductDbContext _dbContext { get; set; }
        public Repository(ProductDbContext dbContext)
        {
            _dbset = dbContext.Set<T>();
            _dbContext = dbContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var oldentity = await GetByIdAsync(id);
            if (oldentity == null)
            {
                return entity;
            }
            else
            {
                _dbContext.Entry(oldentity).State = EntityState.Detached;
                _dbset.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                await SaveAsync();
                return entity;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return false;

            _dbset.Remove(entity);
            await SaveAsync();
            return true;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
