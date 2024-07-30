using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTodo.Data.Repository.Interface;

public interface IRepositoryBase<TEntity>
    where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsnyc(TEntity entity);
}
