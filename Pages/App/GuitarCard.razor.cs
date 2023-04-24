using Microsoft.AspNetCore.Components;
using RockInStock.Models;

namespace RockInStock.Pages.App
{
    public partial class GuitarCard
    {
        [Parameter]
        public Guitar? Guitar { get; set; }
    }
}
