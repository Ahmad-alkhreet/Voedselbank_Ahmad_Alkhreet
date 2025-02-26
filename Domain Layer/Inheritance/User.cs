using Voedselbank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voedselbank.Domain.Inheritance;

public class User : Person
{
    public int Id { get; private set; }  // ID should be set only inside the class
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public int FamilyMembers { get; private set; }
    public string DietaryRestrictions { get; private set; }
    public int UrgencyScore { get; private set; }

    public User(int id, string name, string email, string password, int familyMembers, string dietaryRestrictions, int urgencyScore)
    {
        Id = id;
        Name = name;
        Email = email;
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