using TrainingGuides.Web.Features.DataProtection.Services;
using TrainingGuides.Web.Features.Shared.Services;

namespace TrainingGuides.Web;

public static class ServiceCollectionExtensions
{
    public static void AddTrainingGuidesServices(this IServiceCollection services)
    {
        services.AddSingleton<IStringEncryptionService, AesEncryptionService>();
        services.AddSingleton<IFormCollectionService, FormCollectionService>();
        services.AddSingleton<ICookieConsentService, CookieConsentService>();

        services.AddTransient<IContentItemRetrieverService, ContentItemRetrieverService>();
        services.AddTransient(typeof(IContentItemRetrieverService<>), typeof(ContentItemRetrieverService<>));
    }
}
