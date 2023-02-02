using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace OvetimePolicies;

public class CalculatorProvider : ICalculatorProvider
{
    readonly IServiceProvider _serviceProvider;

    public CalculatorProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICalculator GetCalculator(string calculator)
    {
        var services= _serviceProvider.GetServices<ICalculator>().ToList();
        return services.FirstOrDefault(x => x.Name.ToLower() == calculator.ToLower());
    }
}
