using AspNetCore.Unobtrusive.Ajax;
using Kentico.Content.Web.Mvc.Routing;
using KBank.Web.Extensions;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Kentico.Activities.Web.Mvc;
using Kentico.OnlineMarketing.Web.Mvc;
using Kentico.CrossSiteTracking.Web.Mvc;
using KBank.Web.Helpers.Cookies;
using System.Linq;
using KBank.Web.Components;
using KBank;

var KBankAllowSpecificOrigins = "_kBankAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy(name: KBankAllowSpecificOrigins,
        policy => {
            policy.WithOrigins("https://the-domain-of-your-external-site.com").WithHeaders("content-type").AllowCredentials();
        });
});

// Enable desired Kentico Xperience features
builder.Services.AddKentico(features => {
    var cookieConsentMapping = CookieConsentHelper.GetCurrentMapping().Result;
    features.UseCrossSiteTracking(
        new CrossSiteTrackingOptions {
            ConsentSettings = new[] {
                new CrossSiteTrackingConsentOptions
                {
                    ConsentName = cookieConsentMapping.MarketingConsentCodeName.FirstOrDefault(),
                    AgreeCookieLevel = CookieLevel.Visitor.Level
                }

            }
        });

    features.UsePageBuilder(new PageBuilderOptions {
        DefaultSectionIdentifier = ComponentIdentifiers.SINGLE_COLUMN_SECTION,
        RegisterDefaultSection = false,
        ContentTypeNames = new[] {
            LandingPage.CONTENT_TYPE_NAME,
            ArticlePage.CONTENT_TYPE_NAME,
            DownloadsPage.CONTENT_TYPE_NAME,
            EmptyPage.CONTENT_TYPE_NAME,
        }
    });
    features.UseActivityTracking();
    features.UseWebPageRouting();
});

builder.Services.Configure<CookieLevelOptions>(options => {
    options.CookieConfigurations.Add(CookieNames.COOKIE_CONSENT_LEVEL, CookieLevel.System);
    options.CookieConfigurations.Add(CookieNames.COOKIE_ACCEPTANCE, CookieLevel.System);
});

builder.Services.AddAuthentication();

builder.Services.AddUnobtrusiveAjax();

builder.Services.AddKBankServices();
builder.Services.AddKBankPageTemplateServices();

builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddMvcLocalization();

builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

app.InitKentico();
app.UseStaticFiles();
app.UseKentico();

app.UseCookiePolicy();

app.UseAuthentication();

app.Kentico().MapRoutes();

app.UseCors(KBankAllowSpecificOrigins);

app.Run();