using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Tests
{
    public class TaxCalculatorFixture
    {
        public TaxCalculator Calculator { get; }

        public TaxCalculatorFixture()
        {
            Calculator = new TaxCalculator();
        }
    }
}
