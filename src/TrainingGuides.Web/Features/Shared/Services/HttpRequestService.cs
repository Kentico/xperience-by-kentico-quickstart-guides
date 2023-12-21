using Kentico.Content.Web.Mvc.Routing;

namespace TrainingGuides.Web.Features.Shared.Services;

public class HttpRequestService : IHttpRequestService
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IPreferredLanguageRetriever preferredLanguageRetriever;
    private const string WEB_PAGE_URL_PATHS = "Kentico.WebPageUrlPaths";

    public HttpRequestService(IHttpContextAccessor httpContextAccessor,
    IPreferredLanguageRetriever preferredLanguageRetriever)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.preferredLanguageRetriever = preferredLanguageRetriever;
    }
    private string GetBaseUrl(HttpRequest currentRequest)
    {
        string pathBase = currentRequest.PathBase.ToString();
        string baseUrl = $"{currentRequest.Scheme}://{currentRequest.Host}";

        return string.IsNullOrWhiteSpace(pathBase) ? baseUrl : $"{baseUrl}{pathBase}";
    }

    /// <summary>
    /// Retrieves Base URL from the current request context.
    /// </summary>
    /// <returns>The base URL. If current request contains language, it will NOT be returned with the base URL.</returns>
    public string GetBaseUrl()
    {
        var currentRequest = httpContextAccessor?.HttpContext?.Request;
        return GetBaseUrl(currentRequest);
    }

    /// <summary>
    /// Retrieves Base URL from the current request context. If current site is in a language variant, returns language with the base URL as well
    /// </summary>
    /// <returns>The base URL in current language variant. (e.g. website.com or website.com/es)</returns>
    public string GetBaseUrlWithLanguage()
    {
        var currentRequest = httpContextAccessor?.HttpContext?.Request;
        var webPageUrlPathList = ((string)currentRequest.RouteValues[WEB_PAGE_URL_PATHS])?.Split('/').ToList() ?? [];
        string language = preferredLanguageRetriever.Get();

        bool notPrimaryLanguage = webPageUrlPathList.Contains(language);

        return GetBaseUrl(currentRequest)
            + (notPrimaryLanguage
                ? $"/{language}"
                : string.Empty);
    }
}
