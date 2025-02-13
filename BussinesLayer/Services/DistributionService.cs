using Microsoft.EntityFrameworkCore;               
using Database;                 // If `DatabaseLayer` is another project
using Domain.Models;           // If `User` and `FoodProduct` models are in Domain
using Voedselbank.DataAccess.Repositories;       // Assuming repositories are in DataAccess(DAL)



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

