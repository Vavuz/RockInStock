using Microsoft.EntityFrameworkCore;

namespace RockInStock.Models
{
    public class GuitarRepository : IGuitarRepository
    {
        private readonly RockInStockDbContext _rockInStockDbContext;

        public GuitarRepository(RockInStockDbContext rockInStockDbContext)
        {
            _rockInStockDbContext = rockInStockDbContext;
        }

        public IEnumerable<Guitar> AllGuitars
        {
            get { return _rockInStockDbContext.Guitars.Include(c => c.Category); }
        }

        public IEnumerable<Guitar> GuitarsOfTheMonth
        {
            get { return _rockInStockDbContext.Guitars.Include(c => c.Category).Where(g => g.IsGuitarOfTheMonth); }
        }

        public Guitar? GetGuitarById(int guitarId)
        {
            return _rockInStockDbContext.Guitars.FirstOrDefault(g => g.Id == guitarId);
        }

        public IEnumerable<Guitar> SearchGuitars(string searchQuery)
        {
            return _rockInStockDbContext.Guitars.Where(g => g.Name.Contains(searchQuery));
        }
    }
}
