using Microsoft.EntityFrameworkCore;

namespace Stock_Project.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
            .HasMany(s => s.ItemStores)
            .WithOne(i => i.Store)
            .HasForeignKey(i => i.StoreId);
            modelBuilder.Entity<Item>()
            .HasMany(s => s.ItemStores)
            .WithOne(i => i.Item)
            .HasForeignKey(i => i.ItemId);
        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ItemStore> ItemStores { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
