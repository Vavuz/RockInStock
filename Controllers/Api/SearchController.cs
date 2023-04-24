using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RockInStock.Models;

namespace RockInStock.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IGuitarRepository _guitarRepository;
        public SearchController(IGuitarRepository guitarRepository)
        {
            _guitarRepository = guitarRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allGuitars = _guitarRepository.AllGuitars;
            return Ok(allGuitars);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_guitarRepository.AllGuitars.Any(g => g.Id == id))
                return NotFound();

            return Ok(_guitarRepository.AllGuitars.Where(g => g.Id == id));
        }

        [HttpPost]
        public IActionResult SearchGuitars([FromBody] string searchQuery)
        {
            IEnumerable<Guitar> guitars = new List<Guitar>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                guitars = _guitarRepository.SearchGuitars(searchQuery);
            }
            return new JsonResult(guitars);
        }
    }
}
