using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.Database;

namespace DatabaseLayer.Models
{

    public class FoodProduct
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime Houdbaarheid { get; set; }
        public int Beschikbaarheid { get; set; }

    }

}