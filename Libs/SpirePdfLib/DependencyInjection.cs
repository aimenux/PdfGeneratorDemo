using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace SpirePdfLib;

public static class DependencyInjection
{
    public static IServiceCollection AddSpirePdfLib(this IServiceCollection services)
    {
        services.AddTransient<IPdfGenerator, PdfGenerator>();
        return services;
    }
}