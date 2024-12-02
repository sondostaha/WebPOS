using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebPOS.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace WebPOS.DTO
{
    //[JsonConverter(typeof(StringEnumConverter))]

    public enum ReadyByDefault : byte
    { 
        False =1, 
        True =0, 
        Defual = False 
    } 
    public class ItemsDto
    {
   
        [Required]

        public string Title { get; set; }

        public decimal Price { get; set; }
      
        public int categoryId { get; set; }
        public IFormFile? Photo { get; set; }
        public ReadyByDefault ready_by_default { get; set; }
      
        public int Active { get; set; } = 0;
        public int ActiveKiosk { get; set; } = 1;
        //[JsonProperty("itemIngrediatsDtos")]
        //public ICollection<ItemIngrediatsDto>? itemIngrediatsDtos { get; set; } = new List<ItemIngrediatsDto>();
    }
    public class ItemIngrediatsDto
    {
        public int itemId { get; set; }
        public int IngrediatId {  get; set; }
        public int QuentityOfIngrediat {  get; set; }
    }



}
