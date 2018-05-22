using System.Collections.Generic;

namespace AngularWebApi.Interfaces
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(int id, TEntity entity);

    }
}
