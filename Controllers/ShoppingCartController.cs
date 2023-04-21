using Microsoft.AspNetCore.Mvc;
using RockInStock.Models;
using RockInStock.ViewModels;

namespace RockInStock.Controllers
{
    public class ShoppingCartController: Controller
    {
        private readonly IGuitarRepository _guitarRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IGuitarRepository guitarRepository, IShoppingCart shoppingCart)
        {
            _guitarRepository = guitarRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int guitarId)
        {
            var selectedGuitar = _guitarRepository.AllGuitars.FirstOrDefault(g => g.Id == guitarId);

            if (selectedGuitar != null)
            {
                _shoppingCart.AddToCart(selectedGuitar);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int guitarId)
        {
            var selectedGuitar = _guitarRepository.AllGuitars.FirstOrDefault(g => g.Id == guitarId);

            if (selectedGuitar != null)
            {
                _shoppingCart.RemoveFromCart(selectedGuitar);
            }
            return RedirectToAction("Index");
        }
    }
}
