using FluentAssertions;
using Moq;
using ProductWebApi.Modals;
using ProductWebApi.Repositories;
using ProductWebApi.Services;
using Xunit;

namespace ProductWebApi.ProductWebApi.Tests
{
    public class ProductTests_Moq
    {
        [Fact]
        public void GetProductName_WhenProductExists_ReturnsName()
        {
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetById(1)).Returns(new Product { Id = 1, Name = "Pen" });

            var service = new ProductService(mockRepo.Object);
            var result = service.GetProductName(1);

            Assert.Equal("Pen", result);
        }

        [Fact]
        public void GetProductName_WhenProductNotExists_ReturnsNotFound()
        {
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetById(2)).Returns((Product)null);

            var service = new ProductService(mockRepo.Object);
            var result = service.GetProductName(2);

            Assert.Equal("Not Found", result);
        }

        //FluentAssertions
        [Fact]
        public void GetProductName_WhenProductExists_ShouldReturnName()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetById(1)).Returns(new Product { Id = 1, Name = "Pen" });

            var service = new ProductService(mockRepo.Object);

            // Act
            var result = service.GetProductName(1);

            // Assert
            result.Should().Be("Pen")
                  .And.NotBeNullOrEmpty();
        }

        [Fact]
        public void GetProductName_WhenProductDoesNotExist_ShouldReturnNotFound()
        {
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetById(2)).Returns((Product)null);

            var service = new ProductService(mockRepo.Object);

            var result = service.GetProductName(2);

            result.Should().Be("Not Found");
        }

        [Fact]
        public void GetProduct_WhenProductExists_ShouldReturnExpectedProduct()
        {
            // Arrange
            var expectedProduct = new Product { Id = 1, Name = "Pen" };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetById(1)).Returns(expectedProduct);

            var service = new ProductService(mockRepo.Object);

            // Act
            var result = service.GetProduct(1);

            // Assert
            result.Should().NotBeNull()
                  .And.BeOfType<Product>()
                  .And.BeEquivalentTo(expectedProduct);
        }
    }
}
