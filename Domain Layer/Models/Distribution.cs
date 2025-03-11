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
