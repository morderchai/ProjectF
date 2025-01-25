using DB.DbModels;

namespace DB
{
    public interface IGenericRepository<T> where T : BaseDbModel
    {
        public Task<IList<T>> GetAllAsync();
        public Task AddAsync(T item);
        public Task UpdateAsync(T item);
        public Task DeleteAsync(T item);
        public Task DeleteAllAsync();
        public Task<T> GetAsync(int id);
    }
}
