using Voedselbank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voedselbank.Domain.Models
{
    public class Employee : Person
    {
        //  Role is publiek leesbaar, maar kan alleen intern worden gewijzigd
        public string Role { get; private set; }

        // Zorgt ervoor dat Employee altijd een naam, email en rol heeft
        public Employee(string name, string email, string role) : base(name, email)
        {
            Role = role; // Role wordt ingesteld via de constructor
        }

        //  Publieke methode om de rol bij te werken
        public void UpdateRole(string newRole)
        {
            Role = newRole; // Alleen deze methode kan Role wijzigen
        }

        // Object kan zichzelf representeren als een string
        public override string ToString()
        {
            return $"{Name} ({Email}) - Role: {Role}";
        }
    }
}
