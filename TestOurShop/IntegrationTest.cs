using Entits;
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

namespace TestOurShop
{
    public class IntegrationTest:IClassFixture<DataBaseFixture>
    {
        private readonly AdoNetManageContext _context;
        private readonly UserRepository _userRepository;
        private readonly ILogger<OrderServices> _logger;


           
       
        public IntegrationTest(DataBaseFixture fixture)
        {
            _context = fixture.Context;
            _userRepository =new UserRepository(_context); 
            _logger = new NullLogger<OrderServices>();
        }

        [Fact]
        public async Task DB_Login_ReturnsOkResult_WithValidUser()
        {
            // Arrange
            var user = new User { Email = "batya@example.com", Password = "b0583272120!!!" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();



            // Act
            var retrievedUser = await _userRepository.Login(user.Email, user.Password);

            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Email, retrievedUser.Email);
            Assert.Equal(user.Password, retrievedUser.Password);


        }

        [Fact]
        public async Task DB_Login_ReturnsNotFound_WhenUserNotFound()
        {
            // Arrange


            // Act
            var result = await _userRepository.Login("wrongPassword", "nonExistentUser");

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task DB_LogIn_WrongPassword_ReturnsNull()
        {
            // Arrange
            var user = new User { Email = "BatyaOzeri.com", Password = "batya3272120@gmail" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();



            // Act
            var result = await _userRepository.Login("wrongPassword", user.Email);

            // Assert
            Assert.Null(result);
        }



        [Fact]
        public async Task CreateUser_Should_Add_User_To_Database()
        {
            // Arrange


            // Act
            var user = new User { FirstName = "Laiky", LastName = "Shapira", Email = "mmm@gmail.com", Password = "21436@dfgAS@@!" };
            var dbUser = await _userRepository.AddUser(user);

            // Assert
            Assert.NotNull(dbUser);
            Assert.NotEqual(0, dbUser.Id);
            Assert.Equal("mmm@gmail.com", dbUser.Email);

        }





    }
}
