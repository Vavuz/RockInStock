using Microsoft.EntityFrameworkCore;

namespace RockInStock.Models
{
    public class RockInStockDbContext: DbContext
    {
        public RockInStockDbContext(DbContextOptions<RockInStockDbContext> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
