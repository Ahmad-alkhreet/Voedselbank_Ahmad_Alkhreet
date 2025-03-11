using System.Collections.Generic;
using System.Threading.Tasks;
using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Models;

namespace Voedselbank.BusinessLogic.Services
{
    public class FoodProductService
    {
        private readonly IFoodProductRepository _foodProductRepository;

        public FoodProductService(IFoodProductRepository foodProductRepository)
        {
            _foodProductRepository = foodProductRepository;
        }

        public async Task AddFoodProductAsync(FoodProduct foodProduct)
        {
            await _foodProductRepository.AddFoodProductAsync(foodProduct);
        }

        public async Task<IEnumerable<FoodProduct>> GetAllFoodProductsAsync()
        {
            return await _foodProductRepository.GetAllFoodProductsAsync();
        }
    }
}
