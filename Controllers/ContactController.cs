using Microsoft.AspNetCore.Mvc;

namespace RockInStock.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
