using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voedselbank.Domain.Models;



namespace Voedselbank.Domain.Interfaces
{
    public interface IFoodProductRepository
    {
        Task AddFoodProductAsync(FoodProduct product);
        Task UpdateFoodProductAsync(FoodProduct product);
        Task DeleteFoodProductAsync(FoodProduct product);
        Task<FoodProduct> GetFoodProductByIdAsync(int id);
        Task<IEnumerable<FoodProduct>> GetAllFoodProductsAsync();
    }
}


//✅ IEnumerable<> is beter dan List<>(ondersteunt meer collectietypes).
//✅ Asynchrone methoden(Task<>) maken database-aanroepen efficiënter en voorkomen vastlopen.
//✅ Consistente naamgeving met Async (volgens .NET-conventies).
//🚀 Nu is je repository-interface klaar voor schaalbare en moderne database-operaties! 🚀