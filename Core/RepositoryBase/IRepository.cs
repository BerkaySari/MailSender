using Core.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.RepositoryBase
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TPrimaryKey id);
        void Delete(TEntity entity);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity Get(TPrimaryKey id);
        TEntity Get(TEntity entity);
        IQueryable<TEntity> GetAll();

        void AddAsync(TEntity entity);
        void AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task<TEntity> GetAsync(TEntity entity);
    }
}