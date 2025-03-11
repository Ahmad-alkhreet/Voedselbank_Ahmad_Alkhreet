using Voedselbank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Voedselbank.Domain.Inheritance
{
    public class User : Person
    {
        public int Id { get; private set; }
        public string Password { get; private set; }
        public int FamilyMembers { get; private set; }
        public string DietaryRestrictions { get; private set; }
        public int UrgencyScore { get; private set; }

        // hier gebruik ik`base(...) om name en email door te geven aan Person
        public User(int id, string name, string email, string password, int familyMembers, string dietaryRestrictions, int urgencyScore)
            : base(name, email) // hier roep de `Person` constructor aan
        {
            Id = id;
            Password = password;
            FamilyMembers = familyMembers;
            DietaryRestrictions = dietaryRestrictions;
            UrgencyScore = urgencyScore;
        }

        public void UpdateUrgencyScore(int newScore)
        {
            UrgencyScore = newScore;
        }
    }
}
