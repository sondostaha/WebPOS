using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPOS.Models
{
    public class Areas
    {
        public Areas()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        [MaxLength(500)]
        public string AreaName { get; set; }
        public float? Cost { get; set; }
        [ForeignKey(nameof(Branches))]
        public int BranchId { get; set; }
        public virtual Branches? Branches { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<CustomerAddress>? CustomerAddresses { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
