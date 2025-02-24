using System.Collections.Generic;
using System.Linq;
using Voedselbank.Database;
using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Models;
using System.Collections.Generic;


namespace Voedselbank.DataAccess.Repositories;
{
    public interface IFoodProductRepository
    {
        void Add(FoodProduct product);
        void Update(FoodProduct product);
        void Delete(FoodProduct product);
        FoodProduct GetById(int id);
        IEnumerable<FoodProduct> GetAll();
    }
}
