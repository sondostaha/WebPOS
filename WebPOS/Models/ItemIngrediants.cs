using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebPOS.Models
{
    public class ItemIngrediants
    {
        public int Id { get; set; }
        [ForeignKey(nameof(item))]
        public int ItemId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Items item { get; set; }

        [ForeignKey(nameof(ingrediant))]

        public int IngrediantId { get; set; }
        public virtual Ingrediants ingrediant { get; set; }
        public int Quentity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
