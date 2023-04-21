namespace RockInStock.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Guitar Guitar { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
