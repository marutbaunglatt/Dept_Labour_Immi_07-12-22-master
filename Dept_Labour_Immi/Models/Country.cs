//using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dept_Labour_Immi.Models
{
    public class Country
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "နိူင်ငံအမည်ထည့်ရန် လိုအပ်သည်")]
        [DisplayName("နိူင်ငံအမည်")]
        public string Name { get; set; }
    }
}
