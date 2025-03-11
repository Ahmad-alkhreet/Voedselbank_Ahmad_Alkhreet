using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}
