using TrainingGuides.Web.Features.Articles.Services;
using TrainingGuides.Web.Features.DataProtection.Services;
using TrainingGuides.Web.Features.Html.Services;
using TrainingGuides.Web.Features.Products.Services;
using TrainingGuides.Web.Features.Shared.Services;

namespace TrainingGuides.Web;

public static class ServiceCollectionExtensions
{
    public static void AddTrainingGuidesServices(this IServiceCollection services)
    {
        services.AddSingleton<IStringEncryptionService, AesEncryptionService>();
        services.AddSingleton<IFormCollectionService, FormCollectionService>();
        services.AddSingleton<ICookieConsentService, CookieConsentService>();
        services.AddSingleton<IContentItemRetrieverService, ContentItemRetrieverService>();
        services.AddSingleton<IHttpRequestService, HttpRequestService>();
        services.AddSingleton<IArticlePageService, ArticlePageService>();
        services.AddSingleton<IProductPageService, ProductPageService>();
        services.AddSingleton<IComponentStyleEnumService, ComponentStyleEnumService>();

        services.AddScoped<IHeadTagStoreService, HeadTagStoreService>();

        services.AddTransient(typeof(IContentItemRetrieverService<>), typeof(ContentItemRetrieverService<>));
    }
}
