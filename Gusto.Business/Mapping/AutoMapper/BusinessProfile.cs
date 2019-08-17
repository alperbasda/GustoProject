using System.CodeDom;
using AutoMapper;
using Gusto.Entities.BaseTypes;
using Gusto.Entities.ComplexType;

namespace Gusto.Business.Mapping.AutoMapper
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Domain, DomainTableModel>();

            CreateMap<Domain, DetailDomainModel>();

            CreateMap<AddDomainModel, Domain>();

            CreateMap<UpdateDomainModel, Domain>();
        }
    }
}