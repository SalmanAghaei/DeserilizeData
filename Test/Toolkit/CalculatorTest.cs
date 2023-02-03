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
            decimal basicSalary = 5_300_000;
            decimal allowance = 1_000_000;
            decimal transportation = 500_000;
            decimal tax = 0;

            var act=calculatorA.Calculate(basicSalary, allowance, transportation, tax);
            act.Should().Be((basicSalary+ allowance+ transportation)+(basicSalary + allowance)-(tax));
        }
    }
}
