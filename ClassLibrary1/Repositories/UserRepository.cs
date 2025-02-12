


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
            _context.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }


