namespace OvetimePolicies;

public interface ICalculatorProvider
{
    ICalculator GetCalculator(string calculator);
}
