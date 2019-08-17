using System;
using Gusto.Core.Entity.Concrete;
using Gusto.Entities.Enum;

namespace Gusto.Entities.ComplexType
{
    public class DomainTableModel : ViewModel
    {
        public string ProjeAdi { get; set; }

        public ProjeTipi ProjeTipi { get; set; }

        public int YenilemePeriyodu { get; set; }

        public DateTime DomainBitisTarihi { get; set; }

        public string DomainAdi { get; set; }

        public string Sunucu { get; set; }

        public string StatikIp { get; set; }

        public bool SslVarmi { get; set; }
    }
}