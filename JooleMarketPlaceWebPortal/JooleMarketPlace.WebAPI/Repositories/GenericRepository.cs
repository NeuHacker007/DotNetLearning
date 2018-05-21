using JooleMarketPlace.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace JooleMarketPlace.WebAPI.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TEntity Get(string id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList<TEntity>();
        }

        public IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}