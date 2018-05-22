using System.Collections.Generic;

namespace AngularWebApi.Interfaces
{
    interface IRepository<TEntity>
    {
        List<TEntity> GetAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);

    }
}
