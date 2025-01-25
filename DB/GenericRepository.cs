
using DB.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDbModel
    {
        public AppDbContext _context;
        public DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public Task AddAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
