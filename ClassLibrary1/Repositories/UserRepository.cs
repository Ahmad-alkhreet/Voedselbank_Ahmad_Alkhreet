using Voedselbank.Database;          
using Voedselbank.Domain.Inheritance;

namespace Voedselbank.DataAccess.Repositories;

public class UserRepository
{
    private readonly FoodBankContext _context;

    public UserRepository(FoodBankContext context)
    {
        _context = context;
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);  // Gebruikt het User-model
        _context.SaveChanges();
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();  // Geeft een lijst van User-modellen terug
    }
}