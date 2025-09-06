using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace PugPdfLib;

public static class DependencyInjection
{
    public static IServiceCollection AddPugPdfLib(this IServiceCollection services)
    {
        services.AddTransient<IPdfGenerator, HtmlPdfGenerator>();
        return services;
    }
}