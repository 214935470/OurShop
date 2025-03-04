using Entits;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        

        AdoNetManageContext _AdoNetManageContext;

        public UserRepository(AdoNetManageContext manageDbContext) 
        {
            this._AdoNetManageContext = manageDbContext;

        }



    public async Task<User> AddUser(User user)
        {

            await _AdoNetManageContext.Users.AddAsync(user);
            await _AdoNetManageContext.SaveChangesAsync();
            return user;

        }



        public async Task<User> Login(string email, string password)
        {
            User user = await _AdoNetManageContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
          



            return user;




        }

        public async Task<User> GetUserById(int id)
        {
            User user = await _AdoNetManageContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;

        }




        public async Task UpdateUser(int id, User userToUpdate)
        {
            userToUpdate.Id = id;

            _AdoNetManageContext.Users.Update(userToUpdate);

            await _AdoNetManageContext.SaveChangesAsync();






        }








    }
}
