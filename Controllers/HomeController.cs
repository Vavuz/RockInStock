using Microsoft.AspNetCore.Mvc;
using RockInStock.Models;
using RockInStock.ViewModels;

namespace RockInStock.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGuitarRepository _guitarRepository;

        public HomeController(IGuitarRepository guitarRepository)
        {
            _guitarRepository = guitarRepository;
        }

        public IActionResult Index()
        {
            var guitarsOfTheMonth = _guitarRepository.GuitarsOfTheMonth;
            var homeViewModel = new HomeViewModel(guitarsOfTheMonth);
            return View(homeViewModel);
        }
    }
}
