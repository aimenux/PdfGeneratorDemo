using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace SelectPdfLib;

public static class DependencyInjection
{
    public static IServiceCollection AddSelectPdfLib(this IServiceCollection services)
    {
        services.AddTransient<IPdfGenerator, PdfGenerator>();
        services.AddTransient<IPdfGenerator, HtmlPdfGenerator>();
        return services;
    }
}