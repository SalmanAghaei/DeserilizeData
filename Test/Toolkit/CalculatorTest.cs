using FluentAssertions;
using OvetimePolicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Toolkit
{
    public  class CalculatorTest
    {
        [Fact]
        public void Calculate()
        {
            CalculatorA calculatorA = new();
            var act=calculatorA.Calculate(5_300_000, 1_000_000, 500_000, 0);
            act.Should().Be(13_100_000);
        }
    }
}
