using System.ComponentModel;

namespace Dept_Labour_Immi.Models
{
    public class ServiceforThaiWorker
    {
        public int ID { get; set; }
        [DisplayName("Pink Card Service Count")]
        public int? PinkCardServiceCount { get; set; }
        [DisplayName("CI Card Service Count")]
        public int? CICardServiceCount { get; set; }
    }
}
