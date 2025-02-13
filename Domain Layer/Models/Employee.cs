using Voedselbank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voedselbank.Domain.Models
{
    public class Employee : Person
    { // Erft over van Person
        public string Name { get; set; }
        public string Email { get; set; }
    }

}
