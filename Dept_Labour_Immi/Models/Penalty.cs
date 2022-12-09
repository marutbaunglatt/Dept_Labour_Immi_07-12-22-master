using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dept_Labour_Immi.Models
{
    public class Penalty
    {
        public int Id { get; set; }
        [DisplayName("အကြောင်းအရာ")]
        public string? Reason { get; set; }

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
        public string? penaltyType { get; set; }
        [DisplayName("အေဂျင်စီ")]
        [Required(ErrorMessage = "အေဂျင်စီအမည်ကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        public int? AgencyID { get; set; }
        [DisplayName("အေဂျင်စီ")]
        //[Required(ErrorMessage = "အေဂျင်စီအမည်ကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        public Agency? agency { get; set; }

        [NotMapped]
        public int? AgencyTotalCount { get; set; }
      
    }

    public class PenaltyViewModel
    {
        public int? AgencyID { get; set; }
        public int? AgencyTotalCount { get; set; }
    }
}
