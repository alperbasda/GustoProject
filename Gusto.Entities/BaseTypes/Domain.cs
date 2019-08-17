using System;
using Gusto.Core.Entity.Concrete;
using Gusto.Entities.Enum;

namespace Gusto.Entities.BaseTypes
{
    public class Domain :Entity
    {
        public string ProjeAdi { get; set; }

        public ProjeTipi ProjeTipi { get; set; }

        public int YenilemePeriyodu { get; set; }

        public string DomainAdi { get; set; }

        public DateTime DomainBitisTarihi { get; set; }

        public double DomainFiyati { get; set; }

        public string Sunucu { get; set; }

        public DateTime SunucuBitisTarihi { get; set; }

        public double SunucuFiyati { get; set; }

        public bool SslVarmi { get; set; }

        public DateTime? SslBitisTarihi { get; set; }

        public double SslFiyati { get; set; }

        public string StatikIp { get; set; }

        public DateTime StatikIpBitisTarihi { get; set; }

        public double StatikIpFiyati { get; set; }

        public string Not { get; set; }
        
    }
}