
using FluentAssertions;

namespace TaxCalculator.Tests
{
    public class TaxCalculatorTests : IClassFixture<TaxCalculatorFixture>
    {
        private readonly TaxCalculator _taxCalculator;

        public TaxCalculatorTests(TaxCalculatorFixture fixture)
        {
            _taxCalculator = fixture.Calculator;
        }

        [Fact]
        public void CalculateTax_WithValidIncome_ReturnsExpectedTax()
        {

            var tax = _taxCalculator.CalculateTax(1000);

            Assert.Equal(150, tax);
        }

        [Fact]
        public void CalculateTax_WithNegativeIncome_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _taxCalculator.CalculateTax(-100));
        }

        //Fluent Assertions
        [Fact]
        public void CalculateTax_WithPositiveIncome_ShouldReturnCorrectTax()
        {

            // Act
            var result = _taxCalculator.CalculateTax(2000);

            // Assert
            result.Should().Be(300)
                  .And.BePositive()
                  .And.BeLessThan(500);
        }

        [Fact]
        public void CalculateTax_WithNegativeIncome_ShouldThrowArgumentException()
        {

            Action act = () => _taxCalculator.CalculateTax(-100);

            act.Should().Throw<ArgumentException>()
               .WithMessage("Income must be non-negative.");
        }

        [Theory]
        [InlineData(100, 15)]
        [InlineData(200, 30)]
        [InlineData(0, 0)]
        [InlineData(50.5, 7.575)]
        public void CalculateTax_ShouldReturnExpectedTax(decimal amount, decimal expectedTax)
        {

            // Act
            var result = _taxCalculator.CalculateTax(amount);

            // Assert
            result.Should().BeApproximately(expectedTax, 0.01m);
        }
    }
}