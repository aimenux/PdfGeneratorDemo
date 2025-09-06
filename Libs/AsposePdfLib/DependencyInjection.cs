using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AsposePdfLib;

public static class DependencyInjection
{
    public static IServiceCollection AddAsposePdfLib(this IServiceCollection services)
    {
        services.AddTransient<IPdfGenerator, PdfGenerator>();
        return services;
    }
}