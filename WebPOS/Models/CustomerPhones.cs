using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPOS.Models
{
    public class CustomerPhones
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public virtual Customers? Customers { get; set; }
        [Column("PhoneNumber", TypeName = "varchar(191)")]
        public int PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
