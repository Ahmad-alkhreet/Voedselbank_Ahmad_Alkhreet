using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voedselbank.Domain.Models;


namespace Voedselbank.Domain.Interfaces
{
    public interface IFoodProductRepository
    {
        void AddFoodProduct(FoodProduct product);
        void UpdateFoodProduct(FoodProduct product);
        void DeleteFoodProduct(FoodProduct product);
        FoodProduct GetFoodProductById(int id);
        List<FoodProduct> GetAllFoodProducts();
    }
}
