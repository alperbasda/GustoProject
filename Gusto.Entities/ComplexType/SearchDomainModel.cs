using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Gusto.Core.Entity.Concrete;
using Gusto.Entities.BaseTypes;
using Gusto.Entities.Enum;

namespace Gusto.Entities.ComplexType
{
    public class SearchDomainModel : FilterModel<Domain>
    {
        public string ProjeAdi { get; set; }

        public ProjeTipi? ProjeTipi { get; set; }

        public int YenilemePeriyodu { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DomainBitisTarihiBaslangic { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DomainBitisTarihiBitis { get; set; }

        private IQueryable<Domain> ProjeAdiQuery(IQueryable<Domain> queryable)
        {
            if (!string.IsNullOrEmpty(ProjeAdi))
                return queryable.Where(s => s.ProjeAdi.ToLower().Contains(ProjeAdi));
            return queryable;
        }
        private IQueryable<Domain> ProjeTipiQuery(IQueryable<Domain> queryable)
        {
            if (ProjeTipi != null)
                return queryable.Where(s => s.ProjeTipi == ProjeTipi);
            return queryable;
        }

        private IQueryable<Domain> YenilemePeriyoduQuery(IQueryable<Domain> queryable)
        {
            if (YenilemePeriyodu != 0)
                return queryable.Where(s => s.YenilemePeriyodu == YenilemePeriyodu);
            return queryable;
        }
        private IQueryable<Domain> DomainTarihQuery(IQueryable<Domain> queryable)
        {
            if (DomainBitisTarihiBaslangic != null)
                queryable = queryable.Where(s => s.DomainBitisTarihi >= DomainBitisTarihiBaslangic);
            if (DomainBitisTarihiBitis != null)
                queryable = queryable.Where(s => s.DomainBitisTarihi <= DomainBitisTarihiBitis);
            return queryable;
        }

        public override IQueryable<Domain> ExecuteQueryables(IQueryable<Domain> queryable)
        {
            queryable = WithoutPageExecuteQueryable(queryable);
            queryable = PageQueryable(queryable);
            return queryable;
        }

        protected override IQueryable<Domain> WithoutPageExecuteQueryable(IQueryable<Domain> queryable)
        {
            queryable = ProjeAdiQuery(queryable);
            queryable = ProjeTipiQuery(queryable);
            queryable = YenilemePeriyoduQuery(queryable);
            queryable = DomainTarihQuery(queryable);
            return queryable;
        }
    }
}