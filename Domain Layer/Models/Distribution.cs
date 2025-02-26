using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voedselbank.Domain.Models
{
    public class Distribution
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int FoodProductId { get; private set; }
        public DateTime Timestamp { get; private set; }

        public Distribution(int userId, int foodProductId)
        {
            UserId = userId;
            FoodProductId = foodProductId;
            Timestamp = DateTime.UtcNow;
        }
    }
}
