using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPOS.Models
{
    public enum Type
    {
        User = 0,
        MasterAdmin =1,
        Admin=2,
        CallCenterAgent=3,
        Cashier=4,
        Dispatcher=5,
        NotSet = -1
    }
    public class Users : IdentityUser
    {
        public Users()
        {
            Type = Type.User;
        }

        [ForeignKey(nameof(Branches))]
        public int AssocBranch { get; set; }
        public virtual Branches? Branches { get; set; }
        [Column("Type",TypeName ="varchar(191)")]
        [Required]
        public Type Type { get; set; }
        public List<string>? Permissions {  get; set; }
        [Column("GuId", TypeName = "varchar(191)")]
        public string? GuId {  get; set; }
        [Column("CId", TypeName = "varchar(255)")]

        public string? CId { get; set; }
        [Column("Domain",TypeName = "varchar(191)")]
        public string? Domain { get; set; }
        public byte? Status { get; set; } = 1;
        public virtual ICollection<SystemLog>? LogSystems { get; set; }
    }
}
