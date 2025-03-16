using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Voedselbank.Domain.Models;

namespace Voedselbank.Domain.Interfaces
{
    public interface IDistributionStrategy
    {
        Task DistributeAsync(IEnumerable<User> users, IEnumerable<FoodProduct> availableProducts, IFoodProductRepository foodRepo, ILogger logger);
    }
}