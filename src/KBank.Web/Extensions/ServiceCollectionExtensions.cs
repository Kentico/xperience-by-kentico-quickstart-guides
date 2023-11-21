﻿using TrainingGuides.Web.Components.PageTemplates;
using TrainingGuides.Web.Services.Content;
using TrainingGuides.Web.Services.Cryptography;
using TrainingGuides.Web.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace TrainingGuides.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddKBankServices(this IServiceCollection services)
    {
        services.AddSingleton<IStringEncryptionService, AesEncryptionService>();
        services.AddSingleton<CurrentContactIsTrackableService>();
        services.AddTransient(typeof(IContentItemRetrieverService<>), typeof(ContentItemRetrieverService<>));
    }

    public static void AddKBankPageTemplateServices(this IServiceCollection services)
    {
        services.AddSingleton<ArticlePagePageTemplateService>();
        services.AddSingleton<DownloadsPagePageTemplateService>();
        services.AddSingleton<LandingPagePageTemplateService>();
    }
}