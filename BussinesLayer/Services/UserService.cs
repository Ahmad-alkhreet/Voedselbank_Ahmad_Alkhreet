using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Inheritance;
using Voedselbank.Domain.Models;
using Voedselbank.DataAccess.Repositories;


namespace Voedselbank.BusinessLogic.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
