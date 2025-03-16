using System;
using Voedselbank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Voedselbank.Domain.Models
{
    public class FoodProduct
    {
        public int Id { get; private set; }
        private string Name { get; set; }
        private DateTime ExpiryDate { get; set; }
        private int Availability { get; set; }
        private string SoortFood { get; set; }

        public FoodProduct(string name, DateTime expiryDate, int availability, string soortFood)
        {
            Name = name;
            ExpiryDate = expiryDate;
            SetAvailability(availability);
            SoortFood = soortFood;
        }
        public bool IsExpired()
        {
            return DateTime.UtcNow > ExpiryDate;
        }

        public void ReduceAvailability()
        {
            if (Availability > 0)
                Availability--;
        }

        public void SetAvailability(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Availability cannot be negative.");

            Availability = amount;
        }

        // Toegevoegde getter-methoden om toegang te geven tot private properties
        public string GetFoodName() => Name;
        public DateTime GetFoodExpiryDate() => ExpiryDate;
        public int GetFoodAvailability() => Availability;
        public string GetFoodSoort() => SoortFood;
    }
}


