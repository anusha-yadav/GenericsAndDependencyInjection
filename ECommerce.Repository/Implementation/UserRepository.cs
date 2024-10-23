using ECommerce.Common.Models;
using ECommerce.Repository.Contracts;

namespace ECommerce.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new()
        {
            new User{Username = "Test", Password = "Test123", Role = "Admin"},
            new User{Username = "Test1", Password = "Test123", Role = "Customer"},
            new User{Username = "testuser", Password = "password123", Role = "Admin"}
        };
        
        public bool IsValidUser(User user)
        {
            return _users.Any(u => u.Username == user.Username && u.Password == user.Password && u.Role == user.Role);
        }
    }
}
