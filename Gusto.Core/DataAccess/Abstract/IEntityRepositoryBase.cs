using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using Gusto.Core.Entity.Abstract;

namespace Gusto.Core.DataAccess.Abstract
{
    public interface IEntityRepositoryBase<T>
    where T : class, IEntity, new()
    {
        T Find(int id);

        T Get(Expression<Func<T, bool>> filter);

        T Get<TOrd>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrd>> order = null);

        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null);

        IEnumerable<T> GetList<TOrd>(Expression<Func<T, TOrd>> order, Expression<Func<T, bool>> filter = null);

        IEnumerable<T> GetList<TOrd>(Expression<Func<T, TOrd>> order, int skipCount = 0, int takeCount = 1, Expression<Func<T, bool>> filter = null);

        bool Any(Expression<Func<T, bool>> filter = null);

        int Count(Expression<Func<T, bool>> filter = null);

        bool SetState(T entity, EntityState state);
    }
}