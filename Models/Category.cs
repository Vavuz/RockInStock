using System.ComponentModel.DataAnnotations.Schema;

namespace RockInStock.Models
{
    public class Category
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Guitar>? Guitars { get; set; }
    }
}
