using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JooleMarketPlace.WebAPI.Interfaces
{
    interface IRepository<TEntity>
    {
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Remove(TEntity entity);

    }
}
