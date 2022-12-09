using Microsoft.Build.Framework;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Dept_Labour_Immi.Models
{
    public class ThaiSending
    {
        public int ThaiSendingId { get; set; }
        [Required(ErrorMessage = "လိုင်စင်ရ အေဂျင်စီ အမည်ကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("လိုင်စင်ရ အေဂျင်စီ အမည်")]
        public int? AgencyID { get; set; }
        public Agency? agency { get; set; }
        public int? ThaiCompanyID { get; set; }
        public ThaiCompany? thaiCompany { get; set; }
        [Required(ErrorMessage = "ထိုင်း စက်ရုံ၊အလုပ်ရုံအရေအတွက်ကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("ထိုင်း စက်ရုံ၊အလုပ်ရုံအရေအတွက်")]
        public int? CountOfThaiCompany { get; set; }
        [Required(ErrorMessage = "တင်ပြသည့်ရက်စွဲကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("တင်ပြသည့်ရက်စွဲ")]
        [DataType(DataType.Date)]
        public DateTime? ApplyDate { get; set; }
        [Required(ErrorMessage = "စာချုပ်ချုပ်ဆိုသည့်ရက်စွဲကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("စာချုပ်ချုပ်ဆိုသည့်ရက်စွဲ")]
        [DataType(DataType.Date)]
        public DateTime? ContractSigningDate { get; set; }
        [Required(ErrorMessage = "OWIC ပြုလုပ်သည့်ရက်စွဲကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("OWIC ပြုလုပ်သည့်ရက်စွဲ")]
        [DataType(DataType.Date)]
        public DateTime? OWICDate { get; set; }
        [Required(ErrorMessage = "ရန်ကုန်မှထွက်ခွာသည့်ရက်စွဲကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("ရန်ကုန်မှထွက်ခွာသည့်ရက်စွဲ")]
        [DataType(DataType.Date)]
        public DateTime? YangonDepartureDate { get; set; }
        [Required(ErrorMessage = "မြဝတီ၌ညအိပ်ရပ်နားသည့် ရက်စွဲကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("မြဝတီ၌ညအိပ်ရပ်နားသည့်ရက်စွဲ")]
        [DataType(DataType.Date)]
        public DateTime? MWDAwaitingDate { get; set; }
        [Required(ErrorMessage = "မြဝတီ မှ မဲဆောက်/ကော့သောင်းမှ ရနောင်းသို့ ထွက်ခွာ သည့်ရက်စွဲကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("မြဝတီ မှ မဲဆောက်/ကော့သောင်းမှ ရနောင်းသို့ ထွက်ခွာ သည့်ရက်စွဲ")]
        [DataType(DataType.Date)]
        public DateTime? DepartureFromMWDDate { get; set; }
        [Required(ErrorMessage = "စေလွှတ်ရန် တင်ပြသည့် ကျား ဦး​ရေကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("စေလွှတ်ရန် တင်ပြသည့် ကျား ဦး​ရေ")]
        public int? RequestMaleWorker { get; set; }
        [Required(ErrorMessage = "စေလွှတ်ရန် တင်ပြသည့် မ ဦး​ရေကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("စေလွှတ်ရန် တင်ပြသည့် မ ဦး​ရေ")]
        public int? RequestFemaleWorker { get; set; }
        [Required(ErrorMessage = "စေလွှတ်ရန် တင်ပြသည့် စုစုပေါင်းအလုပ်သမားဦး​ရေကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("စေလွှတ်ရန် တင်ပြသည့် စုစုပေါင်းအလုပ်သမားဦး​ရေ")]
        public int? RequestTotalWorkers { get; set; }
        [Required(ErrorMessage = "အမှန်တကယ် စေလွှတ်သည့် ကျား ဦး​ရေကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("အမှန်တကယ် စေလွှတ်သည့် ကျား ဦး​ရေ")]
        public int? PermitMaleWorker { get; set; }
        [Required(ErrorMessage = "အမှန်တကယ် စေလွှတ်သည့် မ ဦး​ရေကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        [DisplayName("အမှန်တကယ် စေလွှတ်သည့် မ ဦး​ရေ")]
        public int? PermitFemaleWorker { get; set; }
        [DisplayName("အမှန်တကယ် စေလွှတ်သည့် စုစုပေါင်းအလုပ်သမားဦး​ရေ")]
        [Required(ErrorMessage = "အမှန်တကယ် စေလွှတ်သည့် စုစုပေါင်းအလုပ်သမားဦး​ရေကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        public int? PermitTotalWorker { get; set; }
        [DisplayName("အေဂျင်စီမှ လိုက်ပါကြီးကြပ်သူ")]
        [Required(ErrorMessage = "အေဂျင်စီမှ လိုက်ပါကြီးကြပ်သူကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        public string? InchargePersonFromAgency { get; set; }
        [DisplayName("မှတ်ချက်")]
        public string? Remark { get; set; }
    }
}
