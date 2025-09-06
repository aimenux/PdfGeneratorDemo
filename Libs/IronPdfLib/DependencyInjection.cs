using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace IronPdfLib;

public static class DependencyInjection
{
    public static IServiceCollection AddIronPdfLib(this IServiceCollection services)
    {
        services.AddTransient<IPdfGenerator, HtmlPdfGenerator>();
        return services;
    }
}