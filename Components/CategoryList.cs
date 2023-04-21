using Microsoft.AspNetCore.Mvc;
using RockInStock.Models;

namespace RockInStock.Components
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryList(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.AllCategories.OrderBy(c => c.Name);
            return View(categories);
        }
    }
}