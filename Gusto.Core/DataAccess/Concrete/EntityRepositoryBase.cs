using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Gusto.Core.DataAccess.Abstract;
using Gusto.Core.Entity.Abstract;

namespace Gusto.Core.DataAccess.Concrete
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public TEntity Find(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public TEntity Get<TOrd>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrd>> order = null)
        {
            using (TContext context = new TContext())
            {
                return order != null ? context.Set<TEntity>().OrderBy(order).FirstOrDefault(filter) : context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter != null ? context.Set<TEntity>().Where(filter).ToList() : context.Set<TEntity>().ToList();
            }
        }

        public IEnumerable<TEntity> GetList<TOrd>(Expression<Func<TEntity, TOrd>> order, Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter != null ? context.Set<TEntity>().OrderBy(order).Where(filter).ToList() : context.Set<TEntity>().OrderBy(order).ToList();
            }
        }

        public IEnumerable<TEntity> GetList<TOrd>(Expression<Func<TEntity, TOrd>> order, int skipCount = 0, int takeCount = 1, Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter != null ? context.Set<TEntity>().OrderBy(order).Skip(skipCount).Take(takeCount).Where(filter).ToList() : context.Set<TEntity>().OrderBy(order).Skip(skipCount).Take(takeCount).ToList();
            }
        }

        public bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter != null ? context.Set<TEntity>().Any(filter) : context.Set<TEntity>().Any();
            }
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter != null ? context.Set<TEntity>().Count(filter) : context.Set<TEntity>().Count();
            }
        }

        public bool SetState(TEntity entity, EntityState state)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = state;
                return context.SaveChanges() > 0;
            }
        }
    }
}