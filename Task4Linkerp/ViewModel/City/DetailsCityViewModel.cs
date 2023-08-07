using System.ComponentModel.DataAnnotations;

namespace Task4Linkerp.ViewModel.City
{
    public class DetailsCityViewModel
    {

        [Display(Name = "Region(AR|EN)")]
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
        public DetailsCityViewModel()
        {
        }
        public DetailsCityViewModel(int id,int code, string nameEN, string nameAR, bool active, string notes)
        {
            Id = id;
            Code = code;
            NameEN = nameEN;
            NameAR = nameAR;
            Active = active;
            Notes = notes;

        }
    }
}
