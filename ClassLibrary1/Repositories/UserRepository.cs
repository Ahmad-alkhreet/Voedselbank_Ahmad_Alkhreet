using System.Collections.Generic;
using System.Linq;
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

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
