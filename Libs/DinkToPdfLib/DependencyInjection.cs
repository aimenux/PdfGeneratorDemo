using Contracts;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace DinkToPdfLib;

public static class DependencyInjection
{
    public static IServiceCollection AddDinkToPdfLib(this IServiceCollection services)
    {
        services.AddTransient<IConverter>(_ => new StaSynchronizedConverter(new PdfTools()));
        services.AddTransient<IPdfGenerator, HtmlPdfGenerator>();
        return services;
    }
}