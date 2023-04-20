using Microsoft.AspNetCore.Mvc;
using RockInStock.Models;
using RockInStock.ViewModels;

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

        public IActionResult List()
        {
            GuitarListViewModel guitarListViewModel = new GuitarListViewModel(
                _guitarRepository.AllGuitars, "All Guitars");
            return View(guitarListViewModel);
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
    }
}
