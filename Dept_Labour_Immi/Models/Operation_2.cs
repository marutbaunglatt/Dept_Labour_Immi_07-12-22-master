using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dept_Labour_Immi.Models
{
    public class Operation_2
    {
        public int ID { get; set; }

        [DisplayName("တင်ပြသည့်ရက်စွဲ")]
        [DataType(DataType.Date)]
        public DateTime Apply_Date { get; set; }


        [DisplayName("စာချုပ်ချုပ်ဆိုရန်တောင်းဆိုသည့် ရက်စွဲ")]
        [DataType(DataType.Date)]
        public DateTime Contract_Request_Date { get; set; }


        [DisplayName("​မြန်မာအေဂျင်စီ")]
        public int? AgencyID { get; set; }
        public Agency? agency { get; set; }


        [DisplayName("ထိုင်းကုမ္ပဏီအမည်")]
        public int? ThaiCompanyID { get; set; }
        public ThaiCompany? thaiCompany { get; set; }

        [DisplayName("စာအမှတ်")]
        [Required(ErrorMessage = "စာအမှတ်ရွေးရန် လိုအပ်သည်")]
        public int DOEID { get; set; }

        public DOE  dOE { get; set; }
        [DisplayName("အလုပ်အမျိုးအစား")]
        public string WorkType { get; set; }

        [DisplayName("အလုပ်​ခေါ်စာ ကျား ဦး​ရေ")]
        public int? Request_Male_Worker { get; set; }
        [DisplayName("အလုပ်​ခေါ်စာ မ ဦး​ရေ")]
        public int? Request_Female_Worker { get; set; }
        [DisplayName("အလုပ်​ခေါ်စာ အလုပ်သမားဦး​ရေ")]
        public int? Request_Total_Workers { get; set; }

        [DisplayName("စာချုပ်ချုပ်ဆိုရန် ခွင့်ပြုသည့်ရက်စွဲ")]
        [Required(ErrorMessage = "ခွင့်ပြုသည့်ရက်စွဲ ရွေးရန် လိုအပ်သည်")]
        [DataType(DataType.Date)]
        public DateTime? Contract_Granted_Date { get; set; }

        [DisplayName("စာချုပ်ချုပ်ဆိုခွင့်​တောင်းခံသည့် ကျား ဦး​ရေ")]
        public int? Permit_Male_Worker { get; set; }
        [DisplayName("စာချုပ်ချုပ်ဆိုခွင့်​တောင်းခံသည့် မ ဦး​ရေ")]
        public int? Permit_Female_Worker { get; set; }
        [DisplayName("စာချုပ်ချုပ်ဆိုခွင့်​တောင်းခံသည့် အလုပ်သမားဦး​ရေ")]
        public int Permit_Total_Worker { get; set; }

        [DisplayName("စာချုပ်ချုပ်ဆိုသည့် ကျား ဦး​ရေ")]
        [Required(ErrorMessage = "စာချုပ်ချုပ်ဆိုသည့် ကျား ဦး​ရေ ထည့်ရန်လိုအပ်သည်")]
        public int Actual_Contract_Male_Worker { get; set; }
        [Required(ErrorMessage = "စာချုပ်ချုပ်ဆိုသည့် မ ဦး​ရေ ထည့်ရန်လိုအပ်သည်")]
        [DisplayName("စာချုပ်ချုပ်ဆိုသည့် မ ဦး​ရေ")]
        public int? Actual_Contract_Female_Worker { get; set; }
        [DisplayName("စာချုပ်ချုပ်ဆိုသည့် အလုပ်သမားဦး​ရေ")]
        public int? Actual_Contract_Total_Worker { get; set; }
        [DisplayName("စာချုပ်ချုပ်ဆိုရန် ကျန်ရှိသည့် ကျား ဦးရေ")]
        public int Remain_Male_Worker { get; set; }
        [DisplayName("စာချုပ်ချုပ်ဆိုရန် ကျန်ရှိသည့် မ ဦးရေ")]
        public int Remain_Female_Worker { get; set; }
        [DisplayName("စာချုပ်ချုပ်ဆိုရန် ကျန်ရှိသည့် အလုပ်သမားဦးရေ")]
        public int Remain_Total_Worker { get; set; }
        [DisplayName("မှတ်ချက်")]
        public string? Remark { get; set; }

    }
}
