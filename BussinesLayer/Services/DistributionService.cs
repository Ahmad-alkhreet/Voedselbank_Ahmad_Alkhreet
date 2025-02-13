using Microsoft.EntityFrameworkCore;               
using Database;                 
using Domain.Models;           
using Voedselbank.DataAccess.Repositories;     



namespace BusinessLogic.Services;

public class DistributionService

{
    private readonly UserRepository _userRepo;
    private readonly FoodProductRepository _foodRepo;

    public DistributionService(UserRepository userRepo, FoodProductRepository foodRepo)
    {
        _userRepo = userRepo;
        _foodRepo = foodRepo;
    }

    public void AssignPackages()
    {
        var users = _userRepo.GetAllUsers().OrderByDescending(u => u.UrgencyScore).ToList();
        var foodProducts = _foodRepo.GetAllFoodProducts().Where(f => f.Availability > 0).ToList();

        foreach (var user in users)
        {
            foreach (var product in foodProducts)
            {
                if (product.Availability > 0)
                {
                    // Logica om pakketten toe te wijzen
                    product.Availability--;
                    // Sla distributie op in de database
                }
            }
        }
    }
}

