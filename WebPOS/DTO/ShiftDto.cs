using System.ComponentModel.DataAnnotations.Schema;
using WebPOS.Models;

namespace WebPOS.DTO
{
    public enum Status
    {
        Active =0,
        Closed =1,
    }
    public class ShiftDto
    {
        public Status Status { get; set; }
        //[Column("UserId", TypeName = "nvarchar(450)")]
        public string UserId {  get; set; }
    }
}
