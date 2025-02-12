using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int FamilyMembers {  get; set; }
        public string DietaryRstrictions { get; set; }
        public int UrgenScore { get; set; }
    }
}
