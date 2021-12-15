
using MinimalAPIProjectWith.Net6.Models;

namespace MinimalAPIProjectWith.Net6.Repositories
{
    public class UserRepository
    {
        public static List<User> Users = new()
        {
            new()
            {
                UserName = "ishlolo",
                Email = "iso@hotmail.com",
                Password = "Ishlolo123!",
                FirstName = "ish",
                LastName = "lolo",
                Role = "Administrator"
            },
            new()
            {
                UserName = "iso",
                Email = "ishlolo@hotmail.com",
                Password = "Ishlolo123!",
                FirstName = "iso",
                LastName = "lolo",
                Role = "Standard"
            },
        };
    }
}
