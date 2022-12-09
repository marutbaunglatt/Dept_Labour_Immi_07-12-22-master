using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dept_Labour_Immi.Models
{
    public class InternationalSending
    {
        public int ID { get; set; }
        [DisplayName("နိူင်ငံ")]
        [Required(ErrorMessage = "နိူင်ငံအမည်ရွေးရန် လိုအပ်သည်")]
        public int CountryID { get; set; }
        public Country? Country { get; set; }

        [DisplayName("အေဂျင်စီ")]
        [Required(ErrorMessage = "အေဂျင်စီအမည်ရွေးရန် လိုအပ်သည်")]
        public int AgencyID { get; set; }
        public Agency? Agency { get; set; }

        [DisplayName("ရက်စွဲ")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "ရက်စွဲထည့်ရန် လိုအပ်သည်")]
        public DateTime Date { get; set; }
        [DisplayName("အလုပ်သမားအရေအတွက်")]
        [Required(ErrorMessage = "အလုပ်သမားအရေအတွက်ထည့်ရန် လိုအပ်သည်")]
        public int NumberOfWorker { get; set; }

        [DisplayName("Service For Thai Worker")]
 
        public int? ServiceThaiWorkerID { get; set; }
        public ServiceforThaiWorker? ServiceThaiWorker { get; set; }

    }
}
