using System;
using System.Configuration;
using System.Linq;
using Gusto.Core.Entity.Abstract;

namespace Gusto.Core.Entity.Concrete
{
    public abstract class FilterModel<T> : IPostModel,IFilterModel
        where T : class, IEntity, new()
    {
        private int _page;

        public int Page
        {
            get => _page <= 0 ? 1 : _page;
            set => _page = value <= 0 ? 1 : value;
        }

        public abstract IQueryable<T> ExecuteQueryables(IQueryable<T> queryable);

        protected abstract IQueryable<T> WithoutPageExecuteQueryable(IQueryable<T> queryable);

        public int Count(IQueryable<T> queryable)
        {
            queryable = WithoutPageExecuteQueryable(queryable);
            return queryable.Count();
        }

        public int PageCount(int totalData)
        {
            return (int)Math.Ceiling((decimal)totalData /
                                     Convert.ToInt32(ConfigurationManager.AppSettings["DataPerPage"]));
        }

        protected IQueryable<T> PageQueryable(IQueryable<T> queryable)
        {
            int skipCount = (Page - 1) * 10;
            return queryable.OrderBy(s => s.Id).Skip(skipCount).Take(10);
        }
    }
}