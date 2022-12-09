using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dept_Labour_Immi.Models
{
    public class DOE
    {
        public int ID { get; set; }
        [DisplayName("စာအမှတ်")]
        [Required(ErrorMessage = "စာအမှတ်ထည့်ရန် လိုအပ်သည်")]
        public string DOE_NO { get; set; }

        [DisplayName("ရက်စွဲ")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "ရက်စွဲထည့်ရန် လိုအပ်သည်")]
        public DateTime DOE_Date { get; set; }

        public List<Operation_1> Operation_1s { get; set; }
    }
}
