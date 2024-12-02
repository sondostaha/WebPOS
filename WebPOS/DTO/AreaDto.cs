using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebPOS.Models;

namespace WebPOS.DTO
{
    public class AreaDto
    {
        
        [MaxLength(500)]
        public string AreaName { get; set; }
        public float? Cost { get; set; }
        public int BranchId { get; set; }
      
    }
}
