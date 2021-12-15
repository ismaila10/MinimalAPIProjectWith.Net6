using MinimalAPIProjectWith.Net6.Models;
using MinimalAPIProjectWith.Net6.Repositories;

namespace MinimalAPIProjectWith.Net6.Services
{
    public class UserService : IUserService
    {
        public User Get(UserLogin userLogin)
        {
            User user = UserRepository.Users.FirstOrDefault(
                x => x.UserName.Equals(
                    x.UserName, StringComparison.OrdinalIgnoreCase) 
                    && x.Password.Equals(x.Password)
                );
           
            return user;
        }
    }
}
