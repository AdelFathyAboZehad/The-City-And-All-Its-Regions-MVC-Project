using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task4Linkerp.Models
{
    [Table("City")]
    public class City
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
        [Display(Name = "Active")]
        public bool Active { get; set; }
        [Display(Name = "Notes")]
        [MinLength(3), MaxLength(200)]
        public string Notes { get; set; }

        public ICollection<Region> Regions { get; set; }
        public City(int code, string nameEN, string nameAR, bool active, string notes)
        {
            Code = code;
            NameEN = nameEN;
            NameAR = nameAR;
            Active = active;
            Notes = notes;
            Regions = new List<Region>();
        }
        public City() : this(0, null!, null!, false, null!)
        {
        }
    }
}
