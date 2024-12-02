using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace WebPOS.Models
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum ReadyByDefault { False = 1, True = 0, Defual = False }

    public class Items
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        [ForeignKey("category")]
        public int categoryId { get; set; }
        public virtual Category category { get; set; }
        public byte[]? Photo { get; set; }


        [Column(TypeName = "varchar(20)")]
        public ReadyByDefault ReadyByDefault { get; set; }
        public virtual ICollection<ItemIngrediants>? itemIngrediants { get; set; }
        public int Active { get; set; } = 0;
        public int ActiveKiosk { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }


    }

}
