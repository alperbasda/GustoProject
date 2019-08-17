using Gusto.Core.DataAccess.Concrete;
using Gusto.DataAccess.Abstract;
using Gusto.DataAccess.Core;
using Gusto.Entities.BaseTypes;

namespace Gusto.DataAccess.Concrete
{
    public class DomainDal : EntityRepositoryBase<Domain,GustoContext>, IDomainDal
    {
        
    }
}