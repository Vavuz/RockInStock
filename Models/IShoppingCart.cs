namespace RockInStock.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Guitar guitar);
        int RemoveFromCart(Guitar guitar);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
