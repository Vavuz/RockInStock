namespace RockInStock.Models
{
    public interface IGuitarRepository
    {
        IEnumerable<Guitar> AllGuitars { get; }
        IEnumerable<Guitar> GuitarsOfTheMonth { get; }
        Guitar? GetGuitarById(int guitarId);
    }
}
