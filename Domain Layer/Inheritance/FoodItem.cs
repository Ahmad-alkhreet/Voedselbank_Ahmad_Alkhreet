using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voedselbank.Domain.Inheritance
{
    public abstract class FoodItem
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}