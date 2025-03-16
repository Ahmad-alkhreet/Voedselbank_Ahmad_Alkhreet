using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Models;

namespace Voedselbank.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodBankContext _context;

        public UserRepository(FoodBankContext context)
        {
            _context = context;
        }

        // 🔹 Verbeterde foutafhandeling met logging-optie
        public async Task AddUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Fout bij toevoegen gebruiker: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Fout bij updaten gebruiker: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteUserAsync(User user)
        {
            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Fout bij verwijderen gebruiker: {ex.Message}");
                throw;
            }
        }

        // Gebruik SingleOrDefaultAsync() voor betere controle
        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Fout bij ophalen gebruiker met ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Fout bij ophalen van alle gebruikers: {ex.Message}");
                return new List<User>(); // Voorkomt crash bij fout
            }
        }
    }
}
