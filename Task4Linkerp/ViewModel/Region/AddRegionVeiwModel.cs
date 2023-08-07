using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task4Linkerp.ViewModel.Region
{
    public class AddRegionVeiwModel
    {
        [Display(Name = "Code")]
        public int Code { get; set; }
        [Display(Name = "Name(EN)")]
        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }
        [Display(Name = "Name(AR)")]
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }
        [Display(Name = "City(EN|AR)")]
        public int CityId { get; set; }
 

        public AddRegionVeiwModel(int code, string nameEN, string nameAR, int cityId)
        {
            Code = code;
            NameEN = nameEN;
            NameAR = nameAR;
            CityId = cityId;

        }
        public AddRegionVeiwModel()
        {

        }


    }
}
