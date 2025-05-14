using FakeItEasy;
using FluentAssertions;
using Moq;
using ProductWebApi.Modals;
using ProductWebApi.Repositories;
using ProductWebApi.Services;
using Xunit;

namespace ProductWebApi.ProductWebApi.Tests
{
    public class ProductServiceTests_FakeItEasy
    {
        [Fact]
        public void GetProductName_WhenProductExists_ReturnsName()
        {
            var fakeRepo = A.Fake<IProductRepository>();
            A.CallTo(() => fakeRepo.GetById(1)).Returns(new Product { Id = 1, Name = "Notebook" });

            var service = new ProductService(fakeRepo);
            var result = service.GetProductName(1);

            Assert.Equal("Notebook", result);
        }

        [Fact]
        public void GetProductName_WhenProductNotExists_ReturnsNotFound()
        {
            var fakeRepo = A.Fake<IProductRepository>();
            A.CallTo(() => fakeRepo.GetById(2)).Returns(null);

            var service = new ProductService(fakeRepo);
            var result = service.GetProductName(2);

            Assert.Equal("Not Found", result);
        }

        //Fluent Assertions

        [Fact]
        public void GetProductName_WhenProductExists_ShouldReturnName()
        {
            var fakeRepo = A.Fake<IProductRepository>();
            A.CallTo(() => fakeRepo.GetById(1)).Returns(new Product { Id = 1, Name = "Notebook" });

            var service = new ProductService(fakeRepo);

            var result = service.GetProductName(1);

            result.Should().Be("Notebook");
        }

        [Fact]
        public void GetProductName_WhenProductDoesNotExist_ShouldReturnNotFound()
        {
            var fakeRepo = A.Fake<IProductRepository>();
            A.CallTo(() => fakeRepo.GetById(2)).Returns(null);

            var service = new ProductService(fakeRepo);

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
