using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voedselbank.Domain.Models;
using Xunit;

namespace Unittest_Voedselhulp
{
    public class UserTests
    {
        [Fact]
        public void HasDietaryRestriction_ShouldReturnTrue_WhenRestrictionMatches()
        {
            // Arrange
            var user = new User(1, "Alice", "alice@example.com", "password", 2, "Milk");
            var foodProduct = new FoodProduct("Milk", DateTime.UtcNow.AddDays(5), 1, "Dairy");

            // Act
            bool result = user.HasDietaryRestriction(foodProduct);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasDietaryRestriction_ShouldReturnFalse_WhenNoRestriction()
        {
            // Arrange
            var user = new User(1, "Alice", "alice@example.com", "password", 2, "");
            var foodProduct = new FoodProduct("Milk", DateTime.UtcNow.AddDays(5), 1, "Dairy");

            // Act
            bool result = user.HasDietaryRestriction(foodProduct);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasDietaryRestriction_ShouldReturnTrue_WhenMultipleRestrictionsMatch()
        {
            // Arrange
            var user = new User(1, "Alice", "alice@example.com", "password", 2, "Milk, Nuts");
            var foodProduct = new FoodProduct("Nuts", DateTime.UtcNow.AddDays(5), 1, "Snack");

            // Act
            bool result = user.HasDietaryRestriction(foodProduct);

            // Assert
            Assert.True(result);
        }
    }
}