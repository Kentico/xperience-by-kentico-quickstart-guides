﻿﻿using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Microsoft.AspNetCore.Mvc;
using TrainingGuides;
using TrainingGuides.Web.Features.Shared.Services;

[assembly: RegisterWebPageRoute(
    contentTypeName: DownloadsPage.CONTENT_TYPE_NAME,
    controllerType: typeof(TrainingGuides.Web.Features.Downloads.DownloadsPageController))]

namespace TrainingGuides.Web.Features.Downloads;
public class DownloadsPageController : Controller
{
    private readonly IWebPageDataContextRetriever webPageDataContextRetriver;
    private readonly IWebPageQueryResultMapper webPageQueryResultMapper;
    private readonly IContentItemRetrieverService<DownloadsPage> contentItemRetriever;

    public DownloadsPageController(IWebPageDataContextRetriever webPageDataContextRetriver,
        IWebPageQueryResultMapper webPageQueryResultMapper,
        IContentItemRetrieverService<DownloadsPage> contentItemRetriever)
    {
        this.webPageDataContextRetriver = webPageDataContextRetriver;
        this.webPageQueryResultMapper = webPageQueryResultMapper;
        this.contentItemRetriever = contentItemRetriever;
    }

    public async Task<IActionResult> Index()
    {
        var context = webPageDataContextRetriver.Retrieve();

        var downloadsPage = await contentItemRetriever.RetrieveWebPageById(
            context.WebPage.WebPageItemID,
            DownloadsPage.CONTENT_TYPE_NAME,
            webPageQueryResultMapper.Map<DownloadsPage>,
            2);

        var model = DownloadsPageViewModel.GetViewModel(downloadsPage);
        return new TemplateResult(model);
    }
}