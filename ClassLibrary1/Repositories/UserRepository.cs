using Voedselbank.Database;
using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Inheritance;



namespace Voedselbank.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodBankContext _context;

        public UserRepository(FoodBankContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
