using Microsoft.EntityFrameworkCore;

namespace RockInStock.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly RockInStockDbContext _rockInStockDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(RockInStockDbContext rockInStockDbContext)
        {
            _rockInStockDbContext = rockInStockDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            RockInStockDbContext context = services.GetService<RockInStockDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Guitar guitar)
        {
            var shoppingCartItem =
                    _rockInStockDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Guitar.Id == guitar.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Guitar = guitar,
                    Amount = 1
                };

                _rockInStockDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _rockInStockDbContext.SaveChanges();
        }

        public int RemoveFromCart(Guitar guitar)
        {
            var shoppingCartItem =
                    _rockInStockDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Guitar.Id == guitar.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _rockInStockDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _rockInStockDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _rockInStockDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Guitar)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _rockInStockDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _rockInStockDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _rockInStockDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _rockInStockDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Guitar.Price * c.Amount).Sum();
            return total;
        }
    }
}
