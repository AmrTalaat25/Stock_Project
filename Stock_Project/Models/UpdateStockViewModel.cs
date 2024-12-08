using Microsoft.AspNetCore.Mvc.Rendering;
using Stock_Project.Dtos;

namespace Stock_Project.Models
{

        public class UpdateStockViewModel
        {
            public int StoreId { get; set; }
            public int ItemId { get; set; }
            public int Quantity { get; set; }
            public int Balance { get; set; } 

        // For dropdown lists
        public List<storelookup> Stores { get; set; }
            public List<Itemlookup> Items { get; set; }
        }

    
}
