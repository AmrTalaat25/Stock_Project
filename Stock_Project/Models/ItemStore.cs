using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock_Project.Models
{
    public class ItemStore
    {
        [Key] 
        public int StoreItemId { get; set; }
        public int Stock { get; set; }
        public int StoreId { get; set; }
        public int ItemId { get; set; }

        // Navigation Properties
        public Store Store { get; set; }
        public Item Item { get; set; }


    }
}
