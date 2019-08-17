using System.Linq;
using Gusto.Core.Entity.Abstract;

namespace Gusto.Core.DataAccess.Abstract
{
    public interface IQueryableRepositoryBase<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }

    }
}