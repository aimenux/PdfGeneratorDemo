using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace QuestPdfLib;

public static class DependencyInjection
{
    public static IServiceCollection AddQuestPdfLib(this IServiceCollection services)
    {
        services.AddTransient<IPdfGenerator, PdfGenerator>();
        return services;
    }
}