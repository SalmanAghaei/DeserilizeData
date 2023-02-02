using Microsoft.Extensions.DependencyInjection;

namespace OvetimePolicies;

public static class Extensions
{
    public static IServiceCollection AddCalculators(this IServiceCollection services) =>
        services
        .AddScoped<ICalculator, CalculatorA>()
        .AddScoped<ICalculator, CalculatorB>()
        .AddScoped<ICalculator, CalculatorC>()
        .AddScoped<ICalculatorProvider,CalculatorProvider>();
}
