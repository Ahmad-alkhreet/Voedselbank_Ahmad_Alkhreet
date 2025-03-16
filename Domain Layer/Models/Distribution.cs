using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voedselbank.Domain.Models
{
    public class Distribution
    {
        private int Id { get;  set; }
        private int UserId { get;  set; }
        private int FoodProductId { get;  set; }
        private DateTime Timestamp { get;  set; }


        // geen ID nodig alleen bij de data lists gebruik 
        // opjecten gebruiken.
        // Data layers aanpassen
        // data model is aangepast en ook de Layers in de document 


        public Distribution(int userId, int foodProductId)
        {
            UserId = userId;
            FoodProductId = foodProductId;
            Timestamp = DateTime.UtcNow;
        }
    }
}


//public class Distribution
//{
//    // Volledig privé: buiten de klasse nergens direct toegankelijk
//    private int Id { get; set; }
//    private int UserId { get; set; }
//    private int FoodProductId { get; set; }
//    private DateTime Timestamp { get; set; }

//    // Constructor voor NIEUWE distributies (wordt gebruikt als die een nieuwe invoer maakt)
//    public Distribution(int userId, int foodProductId)
//    {
//        UserId = userId;
//        FoodProductId = foodProductId;
//        Timestamp = DateTime.UtcNow;
//    }

//    // Constructor voor bestaande distributies (wordt gebruikt bij ophalen uit database)
//    public Distribution(int id, int userId, int foodProductId, DateTime timestamp)
//    {
//        Id = id;
//        UserId = userId;
//        FoodProductId = foodProductId;
//        Timestamp = timestamp;
//    }

//    // Publieke methode om data veilig op te halen
//    public (int userId, int foodProductId, DateTime timestamp) GetDistributionData()
//    {
//        return (UserId, FoodProductId, Timestamp);
//    }

//    // Debugging en logging gemakkelijker maken
//    public override string ToString()
//    {
//        return $"Distribution - User: {UserId}, Product: {FoodProductId}, Time: {Timestamp}";
//    }
//}