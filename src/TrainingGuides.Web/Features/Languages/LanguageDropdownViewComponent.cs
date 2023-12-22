using Microsoft.AspNetCore.Mvc;
using CMS.ContentEngine;
using CMS.DataEngine;
using Kentico.Content.Web.Mvc.Routing;
using TrainingGuides.Web.Features.Shared.Services;

namespace TrainingGuides.Web.Features.Languages;
public class LanguageDropdownViewComponent : ViewComponent
{
    private readonly IInfoProvider<ContentLanguageInfo> contentLanguageInfoProvider;
    private readonly IPreferredLanguageRetriever preferredLanguageRetriever;
    private readonly IHttpRequestService httpRequestservice;


    public LanguageDropdownViewComponent(
        IInfoProvider<ContentLanguageInfo> contentLanguageInfoProvider,
        IPreferredLanguageRetriever preferredLanguageRetriever,
        IHttpRequestService httpRequestservice)
    {
        this.contentLanguageInfoProvider = contentLanguageInfoProvider;
        this.preferredLanguageRetriever = preferredLanguageRetriever;
        this.httpRequestservice = httpRequestservice;
    }

    public async Task<LanguageDropdownViewModel> GetLanguageMenu()
    {
        var allLanguages = contentLanguageInfoProvider.Get().ToList();

        Dictionary<string, LanguageViewModel> languagesDictionary = [];

        //using foreach here instead of allLanguage.ForEach because Linq does not work well with async and is it not recommended to combine the two 
        foreach (var language in allLanguages)
        {
            string languageCode = language.ContentLanguageName;
            string languageDisplayName = language.ContentLanguageDisplayName;
            string url = await httpRequestservice.GetCurrentPageUrlForLanguage(languageCode);

            languagesDictionary.Add(
                languageCode,
                new LanguageViewModel() { DisplayName = languageDisplayName, CurrentPageUrl = url });
        };

        return new LanguageDropdownViewModel()
        {
            AvailableLanguages = languagesDictionary,
            SelectedLanguage = preferredLanguageRetriever.Get()
        };
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await GetLanguageMenu();
        return View("~/Features/Languages/LanguageDropdown.cshtml", model);
    }
}
