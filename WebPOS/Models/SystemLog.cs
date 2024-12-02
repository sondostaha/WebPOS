using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace WebPOS.Models
{
    public class SystemLog
    {
        [Key]
        public int Id { get; set; }
        public string Details { get; set; }
        [ForeignKey(nameof(Users))]
        public string UserId { get; set; }
        public virtual Users? Users { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
