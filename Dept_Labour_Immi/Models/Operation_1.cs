using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dept_Labour_Immi.Models
{
    public class Operation_1
    {
        public int Id { get; set; }

        [DisplayName("တင်ပြသည့်ရက်စွဲ")]
       // [DisplayName("Apply_Date")]
        [DataType(DataType.Date)]
        public DateTime Apply_Date { get; set; }

      //  [DisplayName("Document_Complete_Date")]
        [DisplayName("စာရွက်စာတမ်းပြည့်စုံသည့်ရက်စွဲ")]
        [DataType(DataType.Date)]
        public DateTime Document_Complete_Date { get; set; }

        //[DisplayName("အေဂျင်စီ")]
        [Required(ErrorMessage = "အေဂျင်စီအမည်ကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        public int? AgencyID { get; set; }
        [DisplayName("အေဂျင်စီ")]
        public Agency? agency { get; set; }

        //[DisplayName("ထိုင်းကုမ္ပဏီ")]
        public int? ThaiCompanyID { get; set; }
        [DisplayName("ထိုင်းကုမ္ပဏီ")]
        public ThaiCompany? thaiCompany { get; set; }
        //[DisplayName("စာအမှတ်")]
        [Required(ErrorMessage = "စာအမှတ်ကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        public int DOEID { get; set; }
        [DisplayName("စာအမှတ်")]
        public DOE  dOE { get; set; }
        [DisplayName("Work Type")]
        public string WorkType { get; set; }
        [DisplayName("ကျား")]
        [Required(ErrorMessage = "ကျား ဦးရေကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        public int MaleWorkers { get; set; }
        [DisplayName("မ")]
        [Required(ErrorMessage = "မ ဦးရေကို ဖြည့်ရန်လိုအပ်ပါသည်။")]
        public int FemaleWorkers { get; set; }
        [DisplayName("စုစုပေါင်း")]
        public int TotalWorkers { get; set; }
        [DisplayName("မှတ်ချက်")]
        public string? Remark { get; set; }
        [DisplayName("DOEDate")]
        [DataType(DataType.Date)]
        public DateTime DOEDate { get; set; }
        [NotMapped]
        public string? DOEDateFromDOE { get; set; }

    }
}
