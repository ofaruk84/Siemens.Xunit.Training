
namespace TaxCalculator { 
public class TaxCalculator
{
    public decimal CalculateTax(decimal income)
    {
        if (income < 0) throw new ArgumentException("Income must be non-negative.");
        return income * 0.15m;
    }
}
}