using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using WebPOS.Migrations;

namespace WebPOS.Models
{
    public class Ingrediants
    {
        [Key]
        public int Id { get; set; }

        public string ingrediant { get; set; }
        
        public virtual ICollection<ItemIngrediants>? itemIngrediants { get; set; }

    }
}
