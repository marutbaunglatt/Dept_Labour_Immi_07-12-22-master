//using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dept_Labour_Immi.Models
{
    public class ThaiCompany
    {
        public int ID { get; set; }
        [DisplayName("ထိုင်းကုမ္ပဏီအမည်")]
        [Required(ErrorMessage = "ထိုင်းကုမ္ပဏီအမည်ထည့်ရန် လိုအပ်သည်")]
        public string CompanyName { get; set; }

        [DisplayName("​မြန်မာအေဂျင်စီ")]
        public int? AgencyID { get; set; }
        public Agency agency { get; set; }
        [DisplayName("အမျိုးအစား")]
        public string? CompanyType { get; set; }
        [DisplayName("ပိုင်ရှင်")]
        [Required(ErrorMessage = "ပိုင်ရှင်အမည်ထည့်ရန် လိုအပ်သည်")]
        public string Owner { get; set; }
        [DisplayName("Code")]
        public string? OwnerCode { get; set; }
        public List<Blacklist> blacklists { get; set; }
        public List<Operation_1> Operation_1s { get; set; }
        [NotMapped]
        public Blacklist blacklist { get; set; }
    }
}
