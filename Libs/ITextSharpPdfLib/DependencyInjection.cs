using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ITextSharpPdfLib;

public static class DependencyInjection
{
    public static IServiceCollection AddITextSharpPdfLib(this IServiceCollection services)
    {
        services.AddTransient<IPdfGenerator, PdfGenerator>();
        return services;
    }
}