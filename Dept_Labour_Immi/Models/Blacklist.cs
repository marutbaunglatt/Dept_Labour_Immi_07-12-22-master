using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dept_Labour_Immi.Models
{
    public class Blacklist
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        [DisplayName("အကြောင်းအရာ")]
        [Required(ErrorMessage = "အကြောင်းအရာကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        public string Reason { get; set; }

        [DisplayName("မှ")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "ရက်စွဲကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        public DateTime FromDate { get; set; }

        [DisplayName("ထိ")]
        [DataType(DataType.Date)]
        public DateTime? Todate { get; set; }
        [DisplayName("မှတ်ချက်")]
        public string? Remark { get; set; }
        public bool IsActive { get; set; }
        [DisplayName("ပြစ်ဒဏ်အမျိုးအစား")]
        [Required(ErrorMessage = "ပြစ်ဒဏ်အမျိုးအစားကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        public string penaltyType { get; set; }
        //foreign key 


        //public List<Agency> agencies { get; set; }  //update comment
        //public List<ThaiCompany> ThaiCompanies { get; set; }
        //public int PenaltyID { get; set; }  //can use if there come more peanlties
        [DisplayName("အေဂျင်စီ")]
        public int? AgencyID { get; set; }
        [DisplayName("အေဂျင်စီ")]
        public Agency? agency { get; set; }
        [DisplayName("ထိုင်းကုမ္ပဏီ")]
        public int? ThaiCompanyID { get; set; }
        [DisplayName("ထိုင်းကုမ္ပဏီ")]
        public ThaiCompany? thaiCompany { get; set; }
    }
}
