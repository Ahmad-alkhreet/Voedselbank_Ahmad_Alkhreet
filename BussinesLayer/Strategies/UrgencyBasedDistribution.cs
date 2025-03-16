using Microsoft.Extensions.Logging;
using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Models;

namespace Voedselbank.BusinessLogic.Strategies
{
    public class UrgencyBasedDistribution : IDistributionStrategy
    {
        public async Task DistributeAsync(IEnumerable<User> users, IEnumerable<FoodProduct> availableProducts, IFoodProductRepository foodRepo, ILogger logger)
        {
            var updatedProducts = new List<FoodProduct>();

            foreach (var user in users.OrderByDescending(u => u.UrgencyScore))
            {
                foreach (var product in availableProducts.Where(p => p.GetFoodAvailability() > 0))
                {
                    if (!user.HasDietaryRestriction(product))
                    {
                        product.ReduceAvailability();
                        updatedProducts.Add(product);
                        logger.LogInformation($"Product {product.GetFoodName()} toegewezen aan {user.Id}");
                        break;
                    }
                }
            }

            if (updatedProducts.Any())
            {
                await foodRepo.UpdateFoodProductsAsync(updatedProducts);
            }
        }
    }
}
