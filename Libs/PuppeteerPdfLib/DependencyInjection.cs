using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace PuppeteerPdfLib;

public static class DependencyInjection
{
    public static IServiceCollection AddPuppeteerPdfLib(this IServiceCollection services)
    {
        services.AddTransient<IPdfGenerator, HtmlPdfGenerator>();
        return services;
    }
}