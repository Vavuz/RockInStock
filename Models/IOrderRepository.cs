namespace RockInStock.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
