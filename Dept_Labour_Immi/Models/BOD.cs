using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dept_Labour_Immi.Models
{
    public class BOD
    {
        public int ID { get; set; }
        [DisplayName("အမည်")]
        [Required(ErrorMessage = "အမည်ထည့်ရန် လိုအပ်သည်")]
        public string Name { get; set; }
        [DisplayName("ရာထူး")]
        public string? Position { get; set; }
        [DisplayName("မှတ်ပုံတင်နံပါတ်")]
        [Required(ErrorMessage = "မှတ်ပုံတင်နံပါတ်ထည့်ရန် လိုအပ်သည်")]
        public string NRC { get; set; }
        [DisplayName("ဖုန်းနံပါတ်")]
        public string? Phone { get; set; }
        [DisplayName("အေဂျင်စီ")]
        public int? AgencyID { get; set; }
        public Agency agency { get; set; }
        [DisplayName("ပြည်နယ် / တိုင်းဒေသကြီးများ")]
        public string? RegionID { get; set; }
        [NotMapped]
        public string? RegionName { get; set; }
    }
}
