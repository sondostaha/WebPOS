using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebPOS.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public int Active { get; set; } = 1;
        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual ICollection<Items>? items { get; set; }
    }
}
