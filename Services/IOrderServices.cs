using Entits;

namespace Services
{
    public interface IOrderServices
    {
        Task<Order> AddOrder(Order order);
        Task<Order> GetOrderById(int id);
    }
}