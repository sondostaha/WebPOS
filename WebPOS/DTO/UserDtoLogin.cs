using System.ComponentModel.DataAnnotations;

namespace WebPOS.DTO
{
    public class UserDtoLogin
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
