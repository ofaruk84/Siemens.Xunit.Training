using Moq;
using ProductWebApi.Modals;
using ProductWebApi.Services;
using Xunit;
using FluentAssertions;

namespace ProductWebApi.ProductWebApi.Tests
{
    public class ProfileServiceTests
    {
        [Fact]
        public void GetOrderHistory_ShouldReturnExpectedOrders()
        {
            // Arrange
            var userId = 10;
            var expectedOrders = new List<Order>
        {
            new Order { Id = 1, UserId = 10, ProductName = "Pen", OrderDate = DateTime.Today },
            new Order { Id = 2, UserId = 10, ProductName = "Notebook", OrderDate = DateTime.Today.AddDays(-1) }
        };

            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(s => s.GetOrdersForUser(userId)).Returns(expectedOrders);

            var profileService = new ProfileService(mockOrderService.Object);

            // Act
            var result = profileService.GetOrderHistory(userId);

            // Assert
            result.Should().NotBeNull()
                  .And.HaveCount(2)
                  .And.BeEquivalentTo(expectedOrders);
        }
    }
}
