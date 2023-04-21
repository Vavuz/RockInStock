using RockInStock.Models;

namespace RockInStock.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RockInStockDbContext _rockInStockDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(RockInStockDbContext rockInStockDbContext, IShoppingCart shoppingCart)
        {
            _rockInStockDbContext = rockInStockDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    GuitarId = shoppingCartItem.Guitar.Id,
                    Price = shoppingCartItem.Guitar.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _rockInStockDbContext.Orders.Add(order);

            _rockInStockDbContext.SaveChanges();
        }
    }
}
