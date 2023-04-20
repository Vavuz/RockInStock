namespace RockInStock.Models
{
    public static class DbInitialiser
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            RockInStockDbContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<RockInStockDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(context => context.Value));
            }

            if (!context.Guitars.Any())
            {
                context.AddRange
                (
                    new Guitar
                    {
                        Name = "Yamaha C40",
                        Price = 122.99M,
                        ShortDescription = "Yamaha C40 Classical Guitar",
                        LongDescription = "Yamaha brings you state-of-the-art warm, balanced sound that comes with even and " +
                        "clear response for high and low notes / All you need for the best technique from the start\r\nFull size" +
                        " classical guitar with 18 frets that combines durability with elegance; the best materials are used for" +
                        " simple, stable and reliable tuning - Quality and strength in one instrument design\r\nEnjoy accurate " +
                        "fret positioning for perfectly tuned sounds even when you play further down the expertly contoured neck" +
                        " / Designed for optimum comfort and good hand positioning\r\nStrong mix of tonewoods used through the " +
                        "body and neck of the guitar to give it a balanced sound / High quality thin gloss finish to add an extra " +
                        "touch of beauty\r\nItems delivered: 1x Yamaha C40II Full Size Classical Guitar with 6 Nylon Strings in " +
                        "Natural Wooden Colour / Guitar info literature",
                        Category = Categories["Classical guitars"],
                        ImageThumbnailUrl = "Images/Thumbnails/1.jpg",
                        ImageUrl = "https://m.media-amazon.com/images/I/51N2zTP-LqL._AC_SY879_.jpg",
                        InStock = true,
                        IsGuitarOfTheMonth = false
                    },
                    new Guitar
                    {
                        Name = "Fender Clapton TR",
                        Price = 2180.98M,
                        ShortDescription = "Fender Clapton Strat Signature TR",
                        LongDescription = "Eric Clapton artist SIGNATURE model\r\nAlder body\r\nMaple neck soft V shape\r\nMaple" +
                        " fretboard with 22 vintage frets\r\n3x Vintage Noiseless pickup (neck, middle, bridge)",
                        Category = Categories["Electric guitars"],
                        ImageThumbnailUrl = "Images/Thumbnails/2.jpg",
                        ImageUrl = "https://thumbs.static-thomann.de/thumb//orig/pics/prod/179406.webp",
                        InStock = true,
                        IsGuitarOfTheMonth = true
                    },
                    new Guitar
                    {
                        Name = "Schecter Orleans",
                        Price = 577.97M,
                        ShortDescription = "Schecter Orleans Studio Acoustic SSTBLK",
                        LongDescription = "With cutaway\r\nTop: Solid cedar\r\nBack and sides: Mahogany\r\nNeck: Mahogany\r\nFretboard: Rosewood",
                        Category = Categories["Acoustic guitars"],
                        ImageThumbnailUrl = "Images/Thumbnails/3.jpg",
                        ImageUrl = "https://thumbs.static-thomann.de/thumb//orig/pics/prod/513493.webp",
                        InStock = false,
                        IsGuitarOfTheMonth = false
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category>? categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genreList = new Category[]
                    {
                        new Category{Name = "Classical guitars", Description = "All classical guitars"},
                        new Category{Name = "Electric guitars", Description = "All electric guitars"},
                        new Category{Name = "Acoustic guitars", Description = "All acoustic guitars"}
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genreList)
                    {
                        categories.Add(genre.Name, genre);
                    }
                }

                return categories;
            }
        }
    }
}
