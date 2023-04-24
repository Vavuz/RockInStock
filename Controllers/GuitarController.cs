using Microsoft.AspNetCore.Mvc;
using RockInStock.Models;
using RockInStock.ViewModels;
using System.IO.Pipelines;

namespace RockInStock.Controllers
{
    public class GuitarController : Controller
    {
        private readonly IGuitarRepository _guitarRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GuitarController(IGuitarRepository guitarRepository, ICategoryRepository categoryRepository)
        {
            _guitarRepository = guitarRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Guitar> guitars;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                guitars = _guitarRepository.AllGuitars.OrderBy(g => g.Id);
                currentCategory = "All guitars";
            }
            else
            {
                guitars = _guitarRepository.AllGuitars.Where(g => g.Category.Name == category)
                    .OrderBy(g => g.Id);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.Name == category)?.Name;
            }

            return View(new GuitarListViewModel(guitars, currentCategory));
        }

        public IActionResult Details(int id)
        {
            var guitar = _guitarRepository.GetGuitarById(id);
            if(guitar == null)
            {
                return NotFound();
            }
            return View(guitar);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
