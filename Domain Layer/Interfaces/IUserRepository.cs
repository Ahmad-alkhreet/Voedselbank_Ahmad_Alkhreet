using System.Collections.Generic;
using Voedselbank.Domain.Inheritance;
using System.Collections.Generic;
using Voedselbank.Domain.Models;
using System.Collections.Generic;


namespace Voedselbank.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();

    }
}
