using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voedselbank.Domain.Models
{
    public class Person
    {
        // Name en Email zijn privé instelbaar, maar publiek leesbaar
        public string Name { get; private set; }
        public string Email { get; private set; }

        // Constructor om de eigenschappen in te stellen
        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
