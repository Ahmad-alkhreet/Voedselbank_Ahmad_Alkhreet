using Voedselbank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voedselbank.Domain.Models
{

    public class User : Person
    {
        public int Id { get; private set; }
        public string Password { get; private set; }
        public int FamilyMembers { get; private set; }
        public string DietaryRestrictions { get; private set; }
        public int UrgencyScore { get; private set; }

        public User(int id, string name, string email, string password, int familyMembers, string dietaryRestrictions)
            : base(name, email)
        {
            Id = id;
            Password = password;
            FamilyMembers = familyMembers;
            DietaryRestrictions = dietaryRestrictions;
            CalculateUrgencyScore();
        }

        public void CalculateUrgencyScore()
        {
            UrgencyScore = FamilyMembers * 2;
            if (!string.IsNullOrEmpty(DietaryRestrictions))
                UrgencyScore += 1;
        }

        public bool HasDietaryRestriction(FoodProduct product)
        {
            return DietaryRestrictions?
                .Split(',', StringSplitOptions.RemoveEmptyEntries) // Voorkomt lege waarden
                .Select(d => d.Trim()) // Verwijdert spaties rondom de restricties
                .Any(d => d.Equals(product.GetFoodName(), StringComparison.OrdinalIgnoreCase)) ?? false;
        }

    }
}