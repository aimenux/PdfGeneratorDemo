using Contracts;
using Microsoft.Extensions.DependencyInjection;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace WkHtmlToPdfLib;

public static class DependencyInjection
{
    public static IServiceCollection AddWkHtmlToPdfLib(this IServiceCollection services)
    {
        services.AddSingleton<IConverter>(_ => new StaSynchronizedConverter(new PdfTools()));
        services.AddTransient<IPdfGenerator, HtmlPdfGenerator>();
        return services;
    }
}