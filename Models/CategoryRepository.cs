namespace RockInStock.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RockInStockDbContext _rockInStockDbContext;

        public CategoryRepository(RockInStockDbContext rockInStockDbContext)
        {
            _rockInStockDbContext = rockInStockDbContext;
        }

        public IEnumerable<Category> AllCategories =>
            _rockInStockDbContext.Categories.OrderBy(g => g.Name);
    }
}
