using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sample.Game.Contracts;
using Sample.Game.Entities;

namespace Sample.Game.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected GameDbContext GameDbContext { get; set; }

        protected RepositoryBase(GameDbContext repositoryContext)
        {
            GameDbContext = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return GameDbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return GameDbContext.Set<T>().Where(expression);
        }
        public void Create(T entity)
        {
            GameDbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            GameDbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            GameDbContext.Set<T>().Remove(entity);
        }
    }
}
