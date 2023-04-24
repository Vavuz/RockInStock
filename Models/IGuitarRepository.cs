namespace RockInStock.Models
{
    public interface IGuitarRepository
    {
        IEnumerable<Guitar> AllGuitars { get; }
        IEnumerable<Guitar> GuitarsOfTheMonth { get; }
        Guitar? GetGuitarById(int guitarId);
        IEnumerable<Guitar> SearchGuitars(string searchQuery);
    }
}
