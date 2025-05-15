using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TaxCalculator.Tests
{
    public class TaxCalculatorTests
    {
        private readonly  TaxCalculator _taxCalculator;
        public TaxCalculatorTests(TaxCalculator taxCalculator)
        {

            _taxCalculator = taxCalculator;

        }
        [Fact]
        public void CalculateTax_WithValidIncome_ReturnsExpectedTax()
        {
            var calculator = new TaxCalculator();

            var tax = calculator.CalculateTax(1000);
            Assert.Equal(150, tax);
        }

        [Fact]
        public void CalculateTax_WithNegativeIncome_ThrowsArgumentException()
        {
            var calculator = new TaxCalculator();
            Assert.Throws<ArgumentException>(() => calculator.CalculateTax(-100));
        }

        //Fluent Assertions
        [Fact]
        public void CalculateTax_WithPositiveIncome_ShouldReturnCorrectTax()
        {
            // Arrange
            var calculator = new TaxCalculator();

            // Act
            var result = calculator.CalculateTax(2000);

            // Assert
            result.Should().Be(300)
                  .And.BePositive()
                  .And.BeLessThan(500);
        }

        [Fact]
        public void CalculateTax_WithNegativeIncome_ShouldThrowArgumentException()
        {
            var calculator = new TaxCalculator();

            Action act = () => calculator.CalculateTax(-100);

            act.Should().Throw<ArgumentException>()
               .WithMessage("Income must be non-negative.");
        }

        [Theory]
        [InlineData(100, 20)]
        [InlineData(200, 40)]
        [InlineData(0, 0)]
        [InlineData(50.5, 10.1)]
        public void CalculateTax_ShouldReturnExpectedTax(decimal amount, decimal expectedTax)
        {
            TaxCalculator _calculator = new();

            // Act
            var result = _calculator.CalculateTax(amount);

            // Assert
            result.Should().BeApproximately(expectedTax, 0.01m);
        }
    }
}
