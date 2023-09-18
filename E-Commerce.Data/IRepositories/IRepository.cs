namespace E_Commerce.Data.IRepositories;

public interface IRepository<TEntity>
{
    public Task<bool> DeleteAsync(long id);
    public Task<List<TEntity>> SelectAllAsync();
    public Task<TEntity> SelectByIdAsync(long id);
    public Task<TEntity> InsertAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
}
