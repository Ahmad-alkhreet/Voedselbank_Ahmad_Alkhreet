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
        void Add(FoodProduct product);
        void Update(FoodProduct product);
        void Delete(FoodProduct product);
        FoodProduct GetById(int id);
        IEnumerable<FoodProduct> GetAll();
    }

}