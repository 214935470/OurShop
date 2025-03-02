using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entits;
using Repository;
using DTO;
using Microsoft.Extensions.Logging;
namespace Services
{
    public class OrderServices : IOrderServices
    {
        private readonly ILogger<OrderServices> _logger;
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



        private async Task<Order> getSum(Order Order)
        {
            float sum = 0;
            foreach (var product in Order.OrderItems)
            {
                Product goodProduct = await ProductRepository.GetById(product.Id);
                sum += (float)goodProduct.Price;
            }
            if (Order.OrderSum != sum)
            {

                Order.OrderSum = sum;
                _logger.LogError("הכניס סכום בכוחות עצמו");
            }

            return Order;
        }


    }
}
