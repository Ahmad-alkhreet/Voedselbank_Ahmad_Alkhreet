
namespace Voedselbank.Domain.Models
{
    public class FoodProduct
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public int Availability { get; private set; }

        public FoodProduct(int id, string name, DateTime expiryDate, int availability)
        {
            Id = id;
            Name = name;
            ExpiryDate = expiryDate;
            Availability = availability;
        }

        public void ReduceAvailability()
        {
            if (Availability > 0)
                Availability--;
        }
    }
}