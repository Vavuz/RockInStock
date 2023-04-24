using Microsoft.AspNetCore.Components;
using RockInStock.Models;

namespace RockInStock.Pages.App
{
    public partial class SearchBlazor
    {
        public string SearchText = "";
        public List<Guitar> FilteredGuitars { get; set; } = new List<Guitar>();

        [Inject]
        public IGuitarRepository? GuitarRepository { get; set; }

        private void Search()
        {
            FilteredGuitars.Clear();
            if (GuitarRepository is not null)
            {
                if (SearchText.Length >= 2)
                    FilteredGuitars = GuitarRepository.SearchGuitars(SearchText).ToList();
            }
        }
    }
}
