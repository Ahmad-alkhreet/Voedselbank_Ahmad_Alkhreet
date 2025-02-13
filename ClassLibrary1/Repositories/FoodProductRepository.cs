using Database;    // Voor de FoodBankContext-klasse
using Domain.Models;     // Voor de FoodProduct-klasse
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Voedselbank.DataAccess.Repositories;

public class FoodProductRepository
{
    private readonly FoodBankContext _context;

    public FoodProductRepository(FoodBankContext context)
    {
        _context = context;
    }

    public void AddFoodProduct(FoodProduct foodProduct)
    {
        _context.FoodProducts.Add(foodProduct);  // Gebruikt het FoodProduct-model
        _context.SaveChanges();
    }

    public List<FoodProduct> GetAllFoodProducts()
    {
        return _context.FoodProducts.ToList();  // Geeft een lijst van FoodProduct-modellen terug
    }
}