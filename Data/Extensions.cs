using System;
using Data.Contexts;
using Data.Repositories;
using Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data;

public static class Extensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
        .AddScoped<IPersonCommandRepository, PersonCommandRepository>()
        .AddScoped<IPersonQueryRepository, PersonQueryRepository>()
        .AddScoped<IPersonSalaryCommandRepository, PersonSalaryCommandRepository>();
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CommandDbContext>(config => config.UseSqlServer(configuration.GetConnectionString("cnn"), builder =>
        {
            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        }));
        return services;
    }
}
