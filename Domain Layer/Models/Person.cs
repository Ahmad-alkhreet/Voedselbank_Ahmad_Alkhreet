using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voedselbank.Domain.Models
{
    public class Person
    {
        protected string Name { get; set; }
        protected string Email { get; set; }

        // Constructor
        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
