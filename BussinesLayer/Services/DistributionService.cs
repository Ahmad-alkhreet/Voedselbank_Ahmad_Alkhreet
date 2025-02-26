using Microsoft.EntityFrameworkCore;
using Voedselbank.Database;
using Voedselbank.Domain.Models;
using Voedselbank.DataAccess.Repositories;
using Voedselbank.Domain.Interfaces;
using System.Linq;

namespace Voedselbank.BusinessLogic.Services
{
    public class DistributionService
    {
        private readonly IUserRepository _userRepo;
        private readonly IFoodProductRepository _foodRepo;

        public DistributionService(IUserRepository userRepo, IFoodProductRepository foodRepo)
        {
            _userRepo = userRepo;
            _foodRepo = foodRepo;
        }

        public void AssignPackages()
        {
            var users = _userRepo.GetAllUsers()
                                 .OrderByDescending(u => u.UrgencyScore)
                                 .ToList();

            var availableProducts = _foodRepo.GetAllFoodProducts()
                                             .Where(p => p.Availability > 0)
                                             .ToList();

            foreach (var user in users)
            {
                foreach (var product in availableProducts.Where(p => p.Availability > 0))
                {
                    product.ReduceAvailability();
                    _foodRepo.UpdateFoodProduct(product);
                }
            }
        }
    }
}
