using Microsoft.Extensions.DependencyInjection;

namespace SubsequenceLib;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddSubsequenceServices(this IServiceCollection services)
    {
        services.AddTransient<ISubsequenceOperations, SubsequenceOperations>();
        return services;
    }
}