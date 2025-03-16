using System.Collections.Generic;
using System.Threading.Tasks;
using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Inheritance;
using Voedselbank.Domain.Models;

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
            try
            {
                user.CalculateUrgencyScore(); //  Eerst de urgentiescore berekenen

                await _userRepository.AddUserAsync(user); // Gebruiker toevoegen aan database

                Console.WriteLine("Gebruiker succesvol toegevoegd."); // log een succesbericht
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Fout bij toevoegen gebruiker: {ex.Message}");
                throw; // Optioneel: hergooi de fout als de applicatie deze hogerop moet verwerken
            }
        }

        // Exception handling bij ophalen van gebruikers
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                return await _userRepository.GetAllUsersAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Fout bij ophalen gebruikers: {ex.Message}");
                return new List<User>(); // Voorkomt dat de applicatie crasht bij een fout
            }
        }
    }
}