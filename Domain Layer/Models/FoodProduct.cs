using Voedselbank.Database;
using Voedselbank.Domain.Inheritance;

namespace Voedselbank.Domain.Models;

public class FoodProduct : FoodItem
{
    public int Id { get; set; }                     // Unique ID of the product
    public string Name { get; set; }                // Name of the product
    public DateTime ExpiryDate { get; set; }        // Expiry date of the product
    public int Availability { get; set; }           // Number of available units
}