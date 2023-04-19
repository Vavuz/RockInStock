using RockInStock.Models;

namespace RockInStock.ViewModels
{
    public class GuitarListViewModel
    {
        public IEnumerable<Guitar> Guitars { get; }
        public string? CurrentCategory { get; }

        public GuitarListViewModel(IEnumerable<Guitar> guitars, string? currentCategoy)
        {
            Guitars = guitars;
            CurrentCategory = currentCategoy;
        }
    }
}
