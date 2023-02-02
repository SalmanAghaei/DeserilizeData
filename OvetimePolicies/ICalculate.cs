using Toolkit;
namespace OvetimePolicies;

public interface ICalculator
{
    string Name { get;}
    decimal Calculate(decimal baseSalary, decimal allowance, decimal transportation, decimal tax) =>
        ((baseSalary + allowance + transportation) + (allowance + baseSalary) - (tax));
}
public class CalculatorA : ICalculator
{
    public string Name { get; } = nameof(CalculatorA);
    public decimal Calculate(decimal baseSalary, decimal allowance, decimal transportation, decimal tax) =>
    ((baseSalary + allowance + transportation) + (allowance + baseSalary) - (tax));
}
public class CalculatorB : ICalculator
{
    public string Name { get; } = nameof(CalculatorB);
    public decimal Calculate(decimal baseSalary, decimal allowance, decimal transportation, decimal tax) =>
  ((baseSalary + allowance + transportation) + (allowance + baseSalary) - (tax));
}
public class CalculatorC : ICalculator
{
    public string Name { get; } = nameof(CalculatorC);
    public decimal Calculate(decimal baseSalary, decimal allowance, decimal transportation, decimal tax) =>
  ((baseSalary + allowance + transportation) + (allowance + baseSalary) - (tax));
}
