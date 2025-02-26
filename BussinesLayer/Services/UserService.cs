using System.Collections.Generic;
using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Inheritance;



namespace Voedselbank.BusinessLogic.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}

