using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace PdfSharpLib;

public static class DependencyInjection
{
    public static IServiceCollection AddPdfSharpLib(this IServiceCollection services)
    {
        services.AddTransient<IPdfGenerator, PdfGenerator>();
        services.AddTransient<IPdfGenerator, HtmlPdfGenerator>();
        return services;
    }
}