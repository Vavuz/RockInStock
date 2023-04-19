namespace RockInStock.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{Id = 1, Name = "Classical guitars", Description = "All classical guitars"},
                new Category{Id = 2, Name = "Electric guitars", Description = "All electric guitars"},
                new Category{Id = 3, Name = "Acoustic guitars", Description = "All acoustic guitars"}
            };
    }
}
