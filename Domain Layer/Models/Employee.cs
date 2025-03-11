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
        private string Role { get; set; } // Extra private veld voor functie

        // Constructor
        public Employee(string name, string email, string role) : base(name, email)
        {
            Role = role;
        }

        // Publieke methode om de naam op te vragen (uit `Person`)
        public string GetName()
        {
            return base.Name;
        }

        // Publieke methode om de e-mail op te vragen (uit `Person`)
        public string GetEmail()
        {
            return base.Email;
        }

        // Publieke methode om de rol op te vragen
        public string GetRole()
        {
            return Role;
        }

        // Methode om rol bij te werken
        public void UpdateRole(string newRole)
        {
            Role = newRole;
        }
    }
}
