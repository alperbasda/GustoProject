using Gusto.Entities.ComplexType;
using Gusto.Entities.Responses.Concrete;

namespace Gusto.Business.Abstract
{
    public interface IDomainService
    {
        DataResponse DomainList(SearchDomainModel model);

        DataResponse DomainById(int id);

        DataResponse AddDomain(AddDomainModel model);

        DataResponse DeleteDomain(int id);

        DataResponse UpdateAjaxDataDomain(UpdateDomainModel model);
    }
}