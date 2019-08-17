using System.Data.Entity;
using Gusto.Business.Abstract;
using Gusto.Business.Concrete;
using Gusto.Core.DataAccess.Abstract;
using Gusto.Core.DataAccess.Concrete;
using Gusto.DataAccess.Abstract;
using Gusto.DataAccess.Concrete;
using Gusto.DataAccess.Core;
using Ninject.Modules;

namespace Gusto.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDomainService>().To<DomainManager>();

            Bind<IDomainDal>().To<DomainDal>();

            Bind<DbContext>().To<GustoContext>();

            Bind(typeof(IQueryableRepositoryBase<>)).To(typeof(QueryableRepositoryBase<>));
        }
    }
}