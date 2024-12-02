using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPOS.Models
{
    public enum Status
    {
        Active,
        Closed
    }
    public class Shifts
    {
        public Shifts()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        [MaxLength(191)]
        public string Shift { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ShiftID
        {
            get
            {
                var year = CreatedAt.Year.ToString().Substring(2);
                var month = CreatedAt.Month.ToString("D2");
                var day = CreatedAt.Day.ToString("D2");

                return $"{CreatedAt.Year.ToString()[0]}{year}{month}{day}{Location}{UserId}";
            }
            set
            {
                var year = CreatedAt.Year.ToString().Substring(2);
                var month = CreatedAt.Month.ToString("D2");
                var day = CreatedAt.Day.ToString("D2");
                this.ShiftID = $"{CreatedAt.Year.ToString()[0]}{year}{month}{day}{Location}{UserId}";
            }

        }
        [Column("Status", TypeName = "varchar(50)")]
        public Status Status { get; set; }
        public DateTime? ClosingDate { get; set; }
        [ForeignKey(nameof(Users))]
        [Column("UsersId", TypeName = "nvarchar(450)")]
        public string UserId { get; set; }

        [ForeignKey(nameof(Branches))] 
        public int? Location { get; set; }

        [ForeignKey(nameof(Users))]
        [Column("CreatorsId", TypeName = "nvarchar(450)")]
        public string CreatorId { get; set; }


    }
}
