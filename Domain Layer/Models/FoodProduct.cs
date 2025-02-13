using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Domain.Models;

public class FoodProduct
{
    public int Id { get; set; }                     // Unique ID of the product
    public string Name { get; set; }                // Name of the product
    public DateTime ExpiryDate { get; set; }        // Expiry date of the product
    public int Availability { get; set; }           // Number of available units
}