using Microsoft.EntityFrameworkCore;
using Voedselbank.DataAccess.Repositories;
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

        public async Task AssignPackagesAsync()
        {
            var users = (await _userRepo.GetAllUsersAsync())
                                 .OrderByDescending(u => u.UrgencyScore)
                                 .ToList();

            var availableProducts = (await _foodRepo.GetAllFoodProductsAsync())
                                             .Where(p => p.Availability > 0)
                                             .ToList();

            foreach (var user in users)
            {
                foreach (var product in availableProducts.Where(p => p.Availability > 0))
                {
                    product.ReduceAvailability();
                    await _foodRepo.UpdateFoodProductAsync(product);
                }
            }
        }
    }
}

