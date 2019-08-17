using System;
using System.ComponentModel.DataAnnotations;
using Gusto.Core.Entity.Concrete;
using Gusto.Entities.Enum;

namespace Gusto.Entities.ComplexType
{
    //Neden Entity modelimin aynısını complexType yapıyorum ? 
    //1-) Servis veya api temelli bir sistemle çalışırken entityfreamwork nesneleri ile birlikte gelen serilize edilemeyen property problemine karşı önlem almak
    //2-) Entity modelim üstünde data annotation uygulamak db yapımı bozacaktır.
    //3-) Küçük validasyon düzenlemelerimi database ile oynamadan uygulama bazında düzenleyebiliyorum.

    public class AddDomainModel : PostModel
    {
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(200,ErrorMessage = "Bu alana en fazla {0} karakter girebilirsiniz")]
        public string ProjeAdi { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public ProjeTipi ProjeTipi { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public int YenilemePeriyodu { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(200, ErrorMessage = "Bu alana en fazla {0} karakter girebilirsiniz")]
        public string DomainAdi { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public DateTime DomainBitisTarihi { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public double DomainFiyati { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(200, ErrorMessage = "Bu alana en fazla {0} karakter girebilirsiniz")]
        public string Sunucu { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public DateTime SunucuBitisTarihi { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public double SunucuFiyati { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public bool SslVarmi { get; set; }

        public DateTime? SslBitisTarihi { get; set; }

        public double SslFiyati { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(20, ErrorMessage = "Bu alana en fazla {0} karakter girebilirsiniz")]
        public string StatikIp { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public DateTime StatikIpBitisTarihi { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public double StatikIpFiyati { get; set; }

        [MaxLength(2000, ErrorMessage = "Bu alana en fazla {0} karakter girebilirsiniz")]
        public string Not { get; set; }
    }
}