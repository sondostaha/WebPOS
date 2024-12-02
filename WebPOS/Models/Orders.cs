//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebPOS.Models
//{
//    public enum Status
//    {
//        Preparing,
//        Prepared,
//        Done,
//        Canceled,
        
//    }
//    public class Orders
//    {
//        [Key]
//        public int Id { get; set; }
//        public int OrderId { get; set; }
//        public int ItemId { get; set; }
//        public Items? items { get; set; }
//        public string ItemName { get; set; }
//        public int Quentity { get; set; }
//        [Column("TotalPrice",TypeName ="decimal(10,2)")]
//        public decimal TotalPrice { get; set; }
//        [Column("ItemPrice", TypeName = "decimal(10,2)")]
//        public decimal ItemPrice { get; set; }
//        public Status Status { get; set; }

//    }
//}
