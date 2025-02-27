using Entits;
using Moq;
using Moq.EntityFrameworkCore;
using Repository;
using Repository.UserRepository;

namespace Test
{
    
    public class UnitTest1
    {
        public void TestMethod1()
        {
            [Fact]
            public async Task GetUser_ValidCredentials_ReturnsUser()
            {
                var user = new User() { Email = "batyaOzeri@gmail.com", Password = "batyaOzeri123!" };

                var mockContext = new Mock<AdoNetManageContext>();
                var users = new List<User>() { user };
                mockContext.Setup(x => x.Users).ReturnsDbSet(users);

                var userRepository = new UserRepository(mockContext.Object);

                var result = await userREpository.Login(user.Email, user.Password);

                Assert.Equal(user, result);

            }
        }
    }
}