using MangoWebApi.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoWebApi.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity, in TId> where TEntity : class, IEntity<TId>
    {
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(TId tid);
        Task<bool> Update(TId tid, TEntity entity);
        Task<bool> Delete(TId tid);
    }
}
