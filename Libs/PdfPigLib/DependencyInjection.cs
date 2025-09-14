using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace PdfPigLib;

public static class DependencyInjection
{
    public static IServiceCollection AddPdfPigLib(this IServiceCollection services)
    {
        services.AddTransient<IPdfGenerator, PdfGenerator>();
        return services;
    }
}