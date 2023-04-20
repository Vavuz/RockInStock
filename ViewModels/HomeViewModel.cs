using RockInStock.Models;

namespace RockInStock.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Guitar> GuitarsOfTheMonth { get; }

        public HomeViewModel(IEnumerable<Guitar> guitarsOfTheMonth)
        {
            GuitarsOfTheMonth = guitarsOfTheMonth;
        }
    }
}
