namespace Stock_Project.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Balance { get; set; } = 0;



        // Navigation Property: One Store can have many Items
        public ICollection<ItemStore> ItemStores { get; set; }
    }
}
