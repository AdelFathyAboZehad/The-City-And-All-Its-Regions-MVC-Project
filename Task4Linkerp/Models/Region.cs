using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Task4Linkerp.Models
{
    [Table("Region")]
    public class Region
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Code")]
        public int Code { get; set; }
        [Display(Name = "Name(EN)")]
        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }
        [Display(Name = "Name(AR)")]
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }
        [Display(Name = "City")]
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }

        public Region(int code,string nameEN, string nameAR, int cityId)
        {
            Code= code;
            NameEN = nameEN;
            NameAR = nameAR;
            CityId = cityId;

        }
        public Region() : this(0,null!, null!, 0)
        {
        }
    }
}
