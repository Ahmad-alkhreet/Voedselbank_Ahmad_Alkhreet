using System.Collections.Generic;
using Voedselbank.Domain.Inheritance;
using System.Collections.Generic;
using Voedselbank.Domain.Models;
using System.Collections.Generic;


namespace Voedselbank.Domain.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        User GetUserById(int id);
        List<User> GetAllUsers();
    }
}
