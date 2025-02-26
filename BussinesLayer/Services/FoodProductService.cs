using System.Collections.Generic;
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

        public void AddFoodProduct(FoodProduct foodProduct)
        {
            _foodProductRepository.AddFoodProduct(foodProduct);
        }

        public List<FoodProduct> GetAllFoodProducts()
        {
            return _foodProductRepository.GetAllFoodProducts();
        }
    }
}
