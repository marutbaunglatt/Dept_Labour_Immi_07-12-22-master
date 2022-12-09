using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Dept_Labour_Immi.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string UserId { get; private set; } = System.Guid.NewGuid().ToString("N");


        //[Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [NotMapped] 
        [Required, MinLength(6, ErrorMessage ="Password must be a least 6 lenght")] 
        public string Password { get; set; }


        [NotMapped]
        [Compare("Password")]
        public string ComfirmPassword { get; set; }

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        [Required(ErrorMessage = "Select user role")]
        public string Role { get; set; }
    }
}
