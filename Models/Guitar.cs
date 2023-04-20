namespace RockInStock.Models
{
    public class Guitar
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    // not nullable
        public string? ShortDescription { get; set; }    // nullable, so can be null
        public string? LongDescription { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }
        public bool IsGuitarOfTheMonth { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;    // not nullable
    }
}
