using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebPOS.Models;

namespace WebPOS.DTO
{
    public enum Type
    {
        User = 0,
        MasterAdmin = 1,
        Admin = 2,
        CallCenterAgent = 3,
        Cashier = 4,
        Dispatcher = 5,
    }
    public class UserDto
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Type? Type { get; set; } = DTO.Type.User;
        [Required]
        public int AssocBranch { get; set; } 
        public List<string>? Permissions { get; set; }      
        public string? GuId { get; set; }
        public string? CId { get; set; }
        public string? Domain { get; set; }
        public byte? Status { get; set; } = 1;
    }
}
    