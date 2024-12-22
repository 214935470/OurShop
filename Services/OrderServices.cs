using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entits;
using Repository;
using DTO;
namespace Services
{
    public class OrderServices : IOrderServices
    {
        IOrderRepository orderRepository;


        public OrderServices(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Order> AddOrder(Order order)
        {
            return await orderRepository.AddOrder(order);

        }

        public async Task<Order> GetOrderById(int id)
        {
            return await orderRepository.GetOrderById(id);
        }





    }
}
