namespace RockInStock.Models
{
    public class MockGuitarRepository : IGuitarRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Guitar> AllGuitars =>
            new List<Guitar>()
            {
                new Guitar {Id = 1, Name = "Yamaha C40", Price = 122.99M, ShortDescription = "Yamaha C40 Classical Guitar",
                    LongDescription = "Yamaha brings you state-of-the-art warm, balanced sound that comes with even and " +
                    "clear response for high and low notes / All you need for the best technique from the start\r\nFull size" +
                    " classical guitar with 18 frets that combines durability with elegance; the best materials are used for" +
                    " simple, stable and reliable tuning - Quality and strength in one instrument design\r\nEnjoy accurate " +
                    "fret positioning for perfectly tuned sounds even when you play further down the expertly contoured neck" +
                    " / Designed for optimum comfort and good hand positioning\r\nStrong mix of tonewoods used through the " +
                    "body and neck of the guitar to give it a balanced sound / High quality thin gloss finish to add an extra " +
                    "touch of beauty\r\nItems delivered: 1x Yamaha C40II Full Size Classical Guitar with 6 Nylon Strings in " +
                    "Natural Wooden Colour / Guitar info literature", Category = _categoryRepository.AllCategories.ToList()[0],
                    ImageThumbnailUrl = "Images/Thumbnails/1.jpg", ImageUrl = "https://m.media-amazon.com/images/I/51N2zTP-LqL._AC_SY879_.jpg", InStock = true,
                    IsGuitarOfTheMonth = false},
                new Guitar {Id = 2, Name = "Fender Clapton TR", Price = 2180.98M, ShortDescription = "Fender Clapton Strat Signature TR",
                    LongDescription = "Eric Clapton artist SIGNATURE model\r\nAlder body\r\nMaple neck soft V shape\r\nMaple" +
                    " fretboard with 22 vintage frets\r\n3x Vintage Noiseless pickup (neck, middle, bridge)",
                    Category = _categoryRepository.AllCategories.ToList()[1],
                    ImageThumbnailUrl = "Images/Thumbnails/2.jpg", ImageUrl = "https://thumbs.static-thomann.de/thumb//orig/pics/prod/179406.webp", InStock = true,
                    IsGuitarOfTheMonth = true},
                new Guitar {Id = 3, Name = "Schecter Orleans", Price = 577.97M,
                    ShortDescription = "Schecter Orleans Studio Acoustic SSTBLK",
                    LongDescription = "With cutaway\r\nTop: Solid cedar\r\nBack and sides: Mahogany\r\nNeck: Mahogany\r\nFretboard: Rosewood",
                    Category = _categoryRepository.AllCategories.ToList()[2],
                    ImageThumbnailUrl = "Images/Thumbnails/3.jpg", ImageUrl = "https://thumbs.static-thomann.de/thumb//orig/pics/prod/513493.webp", InStock = false,
                    IsGuitarOfTheMonth = false}
            };

        public IEnumerable<Guitar> GuitarsOfTheMonth
        {
            get
            {
                return AllGuitars.Where(g => g.IsGuitarOfTheMonth);
            }
        }

        public Guitar? GetGuitarById(int guitarId) => AllGuitars.FirstOrDefault(g => g.Id == guitarId);

        public IEnumerable<Guitar> SearchGuitars(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
