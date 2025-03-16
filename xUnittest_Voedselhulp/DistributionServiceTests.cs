using Microsoft.Extensions.Logging;
using Moq;
using Voedselbank.BusinessLogic.Services;
using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Models;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DistributionServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepo;
    private readonly Mock<IFoodProductRepository> _mockFoodRepo;
    private readonly Mock<IDistributionStrategy> _mockStrategy;
    private readonly Mock<ILogger<DistributionService>> _mockLogger;
    private readonly DistributionService _distributionService;

    public DistributionServiceTests()
    {
        _mockUserRepo = new Mock<IUserRepository>();
        _mockFoodRepo = new Mock<IFoodProductRepository>();
        _mockStrategy = new Mock<IDistributionStrategy>();
        _mockLogger = new Mock<ILogger<DistributionService>>();

        _distributionService = new DistributionService(
            _mockUserRepo.Object,
            _mockFoodRepo.Object,
            _mockLogger.Object,
            _mockStrategy.Object
        );
    }

    [Fact]
    public async Task AssignPackagesAsync_ShouldDistributeFoodBasedOnUrgency()
    {
        var users = new List<User>
        {
            new User(1, "Alice", "alice@example.com", "password", 2, ""),
            new User(2, "Bob", "bob@example.com", "password", 4, "")
        };

        var products = new List<FoodProduct>
        {
            new FoodProduct("Apple", DateTime.UtcNow.AddDays(10), 3, "Fruit"),
            new FoodProduct("Milk", DateTime.UtcNow.AddDays(5), 1, "Dairy")
        };

        _mockUserRepo.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(users);
        _mockFoodRepo.Setup(repo => repo.GetAllFoodProductsAsync()).ReturnsAsync(products);

        await _distributionService.AssignPackagesAsync();

        _mockStrategy.Verify(strategy => strategy.DistributeAsync(It.IsAny<IEnumerable<User>>(), It.IsAny<IEnumerable<FoodProduct>>(), It.IsAny<IFoodProductRepository>(), It.IsAny<ILogger>()), Times.Once);
    }
}
