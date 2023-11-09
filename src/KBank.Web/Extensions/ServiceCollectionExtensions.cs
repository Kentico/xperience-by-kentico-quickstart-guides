﻿using KBank.Web.Components.PageTemplates;
using KBank.Web.DataProtection;
using KBank.Web.Services.Content;
using KBank.Web.Services.Cryptography;
using Microsoft.Extensions.DependencyInjection;

namespace KBank.Web.Extensions;

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