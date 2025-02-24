using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Models;

namespace BusinessLogic.Services;

public class FoodProductService {
    private readonly IRepository<FoodProduct> _foodProductRepository;

    public FoodProductService(IRepository<FoodProduct> foodProductRepository)
    {
        _foodProductRepository = foodProductRepository;
    }

    public void AddFoodProduct(FoodProduct foodProduct)
    {
        _foodProductRepository.Add(foodProduct);
    }

    public IEnumerable<FoodProduct> GetAllFoodProducts()
    {
        return _foodProductRepository.GetAll();
    }
}
