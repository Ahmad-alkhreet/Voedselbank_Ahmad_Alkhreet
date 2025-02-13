using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class User
{
    public int Id { get; set; }                     // Unique ID of the user
    public string Name { get; set; }                // Name of the user
    public string Email { get; set; }               // Email of the user
    public string Password { get; set; }            // Password of the user
    public int FamilyMembers { get; set; }          // Number of family members
    public string DietaryRestrictions { get; set; } // Dietary restrictions (e.g., gluten-free)
    public int UrgencyScore { get; set; }           // Urgency of the help request
}