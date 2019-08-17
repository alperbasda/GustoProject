using System.Data.Entity.ModelConfiguration;

namespace Gusto.Entities.BaseTypes.FluentApi
{
    public class DomainMap : EntityTypeConfiguration<Domain>
    {
        //Entity Propertylerin default değeri isrequired olarak gelmesine rağmen hepsini tanımlamayı tercih ettim.
        //ProjeTipi propertysine uygulamanın heryerinde kolayca erişip, karışıklık yaşamamak için enum type olarak atadım.
        public DomainMap()
        {
            ToTable("Domains", "Gusto");
            HasKey(s => s.Id);
            Property(s => s.DomainAdi).IsRequired().HasMaxLength(200);
            Property(s => s.ProjeTipi).IsRequired();
            Property(s => s.YenilemePeriyodu).IsRequired();
            Property(s => s.DomainAdi).IsRequired().HasMaxLength(200);
            Property(s => s.DomainBitisTarihi).IsRequired();
            Property(s => s.DomainFiyati).IsRequired();
            Property(s => s.Sunucu).IsRequired().HasMaxLength(200);
            Property(s => s.SunucuBitisTarihi).IsRequired();
            Property(s => s.SunucuFiyati).IsRequired();
            Property(s => s.SslVarmi).IsRequired();
            Property(s => s.SslBitisTarihi).IsOptional();
            Property(s => s.SslFiyati).IsOptional();
            Property(s => s.StatikIp).IsRequired().HasMaxLength(20);
            Property(s => s.StatikIpBitisTarihi).IsRequired();
            Property(s => s.StatikIpFiyati).IsRequired();
            Property(s => s.Not).IsOptional().HasMaxLength(2000);
        }
    }
}