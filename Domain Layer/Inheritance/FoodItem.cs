using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Voedselbank.Domain.Inheritance
{
    public abstract class FoodItem
    {
        private int Id { get; set; }  
        private string Name { get; set; }

        // Optionele constructor
        protected FoodItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string GetFoodName() => Name;
    }

}
