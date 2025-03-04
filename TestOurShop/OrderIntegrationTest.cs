using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject;
using Entits;

namespace TestOurShop
{
    public class OrderIntegrationTest: IClassFixture<DataBaseFixture>
    {
        private readonly AdoNetManageContext _context;
        private readonly UserRepository _userRepository;
        private readonly ILogger<OrderServices> _logger;
        public OrderIntegrationTest(DataBaseFixture fixture)
        {
            _context = fixture.Context;
            _userRepository = new UserRepository(_context);
            _logger = new NullLogger<OrderServices>();
        }
        [Fact]
        public async Task DB_CreateOrderSum_CHeckOrderSum_ReturnsOrder()
        {
            // Arrange
            _context.Categories.Add(new Category { Name = "food" });
            await _context.SaveChangesAsync();

            List<Product> products = new List<Product> { new() { Price = 6, Name = "Milk", Description = "tasty", Image = "1" }, new() { Price = 20, Name = "eggs", Description = "good", Image = "1" } };
            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();

            var orderItems = new List<OrderItem>() { new() { ProductId = 1 }, new() { ProductId = 2 } };
            var order = new Order { UserId = 1, OrderSum = 26, OrderItems = orderItems };
            var orderService = new OrderServices(new OrderRepository(_context), new ProductRepository(_context), _logger);

            // Act
            var result = await orderService.AddOrder(order);

            // Assert
            Assert.Equal(order, result);
        }
    }
}
