using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPOS.Models
{
    public class CustomerAddress
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public virtual Customers? Customers { get; set; }
        public string Address { get; set; }
        public string? Buildding { get; set; }
        public string? Floor { get; set; }
        public string? Apartment { get; set; }
        [ForeignKey(nameof(Areas))]
        public int AreaId { get; set; }
        public virtual Areas? Areas { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
