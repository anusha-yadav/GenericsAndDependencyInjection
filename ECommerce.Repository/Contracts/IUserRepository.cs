using ECommerce.Common.Models;

namespace ECommerce.Repository.Contracts
{
    /// <summary>
    /// The User Repository interface
    /// </summary>
    public interface IUserRepository
    {
        bool IsValidUser(User user);
    }
}
