using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Entitis;
using Repository;
using Zxcvbn;


namespace Services
{
    public class UserServices : IUserServices
    {
        IUserRepository userRepository;

        public UserServices(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            int a = user.Email.IndexOf('@');
            int b = user.Email.IndexOf(".com");
            if (a != -1 && b != -1 && a<b)
            {  //check password strength
                return userRepository.AddUser(user);
            }
            else
            {
                return (null);
            }
            
        }

        public int cheakPassword(string password)
        {

            var result = Zxcvbn.Core.EvaluatePassword(password);

            return result.Score;

        }

        public User Login(string email, string password)
        {

            return userRepository.Login(email, password);


        }


        public void UpdateUser(int id, User userToUpdate)
        {  //check password strength

            userRepository.UpdateUser(id, userToUpdate);

        }

    }
}
