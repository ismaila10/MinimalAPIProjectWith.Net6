using MinimalAPIProjectWith.Net6.Models;

namespace MinimalAPIProjectWith.Net6.Services
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
}
