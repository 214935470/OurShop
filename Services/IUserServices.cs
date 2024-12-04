using Entits;

namespace Services
{
    public interface IUserServices
    {
        Task<User> AddUser(User user);
        int cheakPassword(string password);
        Task<User> Login(string email, string password);
        Task UpdateUser(int id, User userToUpdate);
    }
}