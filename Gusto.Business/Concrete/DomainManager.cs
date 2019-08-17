using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Gusto.Business.Abstract;
using Gusto.Business.Aspects.ExceptionAspect;
using Gusto.Core.DataAccess.Abstract;
using Gusto.DataAccess.Abstract;
using Gusto.Entities.BaseTypes;
using Gusto.Entities.ComplexType;
using Gusto.Entities.Enum;
using Gusto.Entities.PageModels;
using Gusto.Entities.Responses.Concrete;

namespace Gusto.Business.Concrete
{
    public class DomainManager : IDomainService
    {
        private IDomainDal _domainDal;

        private IQueryableRepositoryBase<Domain> _queryable;

        private IMapper _mapper;

        public DomainManager(IDomainDal domainDal, IQueryableRepositoryBase<Domain> queryable, IMapper mapper)
        {
            _domainDal = domainDal;
            _queryable = queryable;
            _mapper = mapper;
        }
        //[ExceptionAspect]
        public DataResponse DomainList(SearchDomainModel model)
        {
            var domains = model.ExecuteQueryables(_queryable.Table).ToList();
            var totalData = model.Count(_queryable.Table);
            return new DataResponse
            {
                Message = "Domains list",
                Success = true,
                Data = new PageBaseModel
                {
                    CurrentPage = model.Page,
                    TableData = _mapper.Map<List<DomainTableModel>>(domains),
                    TotalData = totalData,
                    TotalPage = model.PageCount(totalData)
                }
            };
        }
        //[ExceptionAspect]
        public DataResponse DomainById(int id)
        {
            var domain = _domainDal.Find(id);
            if (domain != null)
                return new DataResponse
                {
                    Data = _mapper.Map<DetailDomainModel>(domain),
                    Message = domain.ProjeAdi,
                    Success = true,
                };
            return new DataResponse
            {
                Message = "Domain not fount :( :( :(",
                Success = false,
            };
        }

        //[ExceptionAspect]
        public DataResponse AddDomain(AddDomainModel model)
        {

            var domain = _mapper.Map<Domain>(model);
            if (_domainDal.SetState(domain, EntityState.Added))
                return new DataResponse
                {
                    Message = "Domain Added !!!",
                    Success = true
                };
            return new DataResponse
            {
                Message = "Failed to Add :( :( :(",
                Success = false
            };


        }
        //[ExceptionAspect]
        public DataResponse DeleteDomain(int id)
        {
            var domain = _domainDal.Find(id);
            if (domain == null)
                return new DataResponse
                {
                    Message = "Domain Not Found :( :( :(",
                    Success = false
                };
            if (_domainDal.SetState(_domainDal.Find(id), EntityState.Deleted))
                return new DataResponse
                {
                    Message = "Domain Deleted !!!",
                    Success = true
                };
            return new DataResponse
            {
                Message = "Domain Delete Failed :( :( :(",
                Success = false
            };
        }

        //Normal şartlarda kullandığım bir yöntem değil ama jquery/ajax bilgimi gösterebilmek adına bu şekilde kullanıyorum.
        //Bu yüzden update için validasyon kontrolü yapmayacağım.
        //[ExceptionAspect]
        public DataResponse UpdateAjaxDataDomain(UpdateDomainModel model)
        {
            var domain = _domainDal.Get(s => s.Id == model.Id);
            var domainNew = _mapper.Map<Domain>(model);

            foreach (var prop in typeof(Domain).GetProperties())
            {
                if (prop.PropertyType == typeof(DateTime) && Convert.ToDateTime(prop.GetValue(domainNew)) == DateTime.MinValue)
                    continue;
                if (prop.GetValue(domainNew) == null || prop.GetValue(domainNew).ToString()=="0")
                    continue;
                if (prop.GetValue(domainNew) != null)
                {
                    prop.SetValue(domain, prop.GetValue(domainNew));

                }
            }

            if (_domainDal.SetState(domain, EntityState.Modified))
                return new DataResponse
                {
                    Message = "Domain Updated !!!",
                    Success = true
                };
            return new DataResponse
            {
                Message = "Domain Update Failed :( :( :(",
                Success = false
            };
        }


    }
}