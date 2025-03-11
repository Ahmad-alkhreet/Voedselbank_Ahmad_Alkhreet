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
        public int Id { get; private set; } // EF Core zal dit automatisch invullen
        public string Name { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public int Availability { get; private set; }

        // Constructor zonder Id, EF Core regelt dit
        public FoodProduct(string name, DateTime expiryDate, int availability)
        {
            Name = name;
            ExpiryDate = expiryDate;
            SetAvailability(availability);
        }

        // Methode om te controleren of het product over datum is
        public bool IsExpired()
        {
            return DateTime.UtcNow > ExpiryDate;
        }

        // Methode om voorraad te verlagen
        public void ReduceAvailability()
        {
            if (Availability > 0)
                Availability--;
        }

        // Methode om de voorraad in te stellen met een minimumwaarde
        public void SetAvailability(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Availability cannot be negative.");

            Availability = amount;
        }
    }
}
