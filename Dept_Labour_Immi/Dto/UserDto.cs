
using Microsoft.Build.Framework;

namespace Dept_Labour_Immi.Dto
{
    public class UserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
