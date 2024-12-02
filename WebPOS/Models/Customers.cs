using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPOS.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        [Column("Name", TypeName = "varchar(191)")]
        public string Name { get; set; }
        public string? Notes { get; set; }
        public string? InternalNotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<CustomerPhones>? CustomerPhones { get; set; }
        public virtual ICollection<CustomerAddress>? CustomerAddresses { get; set; }


    }
}
