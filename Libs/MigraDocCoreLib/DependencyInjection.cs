using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace MigraDocCoreLib;

public static class DependencyInjection
{
    public static IServiceCollection AddMigraDocCoreLib(this IServiceCollection services)
    {
        services.AddTransient<IPdfGenerator, PdfGenerator>();
        return services;
    }
}