using System.ComponentModel.DataAnnotations;

namespace MCF.Web.Models
{
    public class LoginRequestDto
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
