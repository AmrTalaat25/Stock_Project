using System.ComponentModel.DataAnnotations;

namespace Stock_Project.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 0;
        public ICollection<ItemStore> ItemStores { get; set; }
    }
}
