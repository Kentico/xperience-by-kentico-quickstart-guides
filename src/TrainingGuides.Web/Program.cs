using System.Text;
using AspNetCore.Unobtrusive.Ajax;
using CMS.EmailEngine;
using Kentico.Activities.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.CrossSiteTracking.Web.Mvc;
using Kentico.OnlineMarketing.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using Microsoft.Extensions.Options;
using TrainingGuides;
using TrainingGuides.Web;
using TrainingGuides.Web.Features.DataProtection.Shared;
using TrainingGuides.Web.Features.Shared.Helpers;
using TrainingGuides.Web.Features.Shared.Helpers.Startup;

string trainingGuidesAllowSpecificOrigins = "_trainingGuidesAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: trainingGuidesAllowSpecificOrigins,
        policy =>
        {
            policy
            .WithOrigins("https://The-URL-of-your-external-site.com")
            .WithHeaders("content-type")
            .AllowAnyMethod()
            .AllowCredentials();
        });
});

// Enable desired Kentico Xperience features
builder.Services.AddKentico(async features =>
{
    features.UsePageBuilder(new PageBuilderOptions
    {
        DefaultSectionIdentifier = ComponentIdentifiers.Sections.SINGLE_COLUMN,
        RegisterDefaultSection = false,
        ContentTypeNames = new[] {
            LandingPage.CONTENT_TYPE_NAME,
            ArticlePage.CONTENT_TYPE_NAME,
            DownloadsPage.CONTENT_TYPE_NAME,
            EmptyPage.CONTENT_TYPE_NAME,
            ProductPage.CONTENT_TYPE_NAME
        }
    });
    features.UseCrossSiteTracking(
        new CrossSiteTrackingOptions
        {
            ConsentSettings = new[] {
                new CrossSiteTrackingConsentOptions
                {
                    WebsiteChannelName = "TrainingGuidesPages",
                    ConsentName = await StartupHelper.GetMarketingConsentCodeName(),
                    AgreeCookieLevel = CookieLevel.All.Level
                }
            },
        });
    features.UseActivityTracking();
    features.UseWebPageRouting(new WebPageRoutingOptions { LanguageNameRouteValuesKey = ApplicationConstants.LANGUAGE_KEY });
});

builder.Services.AddXperienceSmtp(options =>
{
    options.Server = new SmtpServer { Host = "localhost", Port = 25 };
});

builder.Services.Configure<CookieLevelOptions>(options =>
{
    options.CookieConfigurations.Add(CookieNames.COOKIE_CONSENT_LEVEL, CookieLevel.System);
    options.CookieConfigurations.Add(CookieNames.COOKIE_ACCEPTANCE, CookieLevel.System);
});

builder.Services.AddAuthentication();

builder.Services.AddUnobtrusiveAjax();

builder.Services.AddTrainingGuidesServices();
builder.Services.AddTrainingGuidesOptions();

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

app.UseCors(trainingGuidesAllowSpecificOrigins);

app.Run();
