﻿using CMS.Websites;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Microsoft.AspNetCore.Mvc;
using TrainingGuides;
using TrainingGuides.Web.Services.Content;

[assembly: RegisterWebPageRoute(ArticlePage.CONTENT_TYPE_NAME, typeof(TrainingGuides.Web.Components.PageTemplates.ArticlePageController))]

namespace TrainingGuides.Web.Components.PageTemplates;
public class ArticlePageController : Controller
{

    private readonly IWebPageDataContextRetriever webPageDataContextRetriever;
    private readonly IWebPageQueryResultMapper webPageQueryResultMapper;
    private readonly IContentItemRetrieverService<ArticlePage> contentItemRetriever;

    public ArticlePageController(IWebPageDataContextRetriever webPageDataContextRetriever,
        IWebPageQueryResultMapper webPageQueryResultMapper,
        IContentItemRetrieverService<ArticlePage> contentItemRetriever)
    {
        this.webPageDataContextRetriever = webPageDataContextRetriever;
        this.webPageQueryResultMapper = webPageQueryResultMapper;
        this.contentItemRetriever = contentItemRetriever;
    }

    public async Task<IActionResult> Index()
    {
        var context = webPageDataContextRetriever.Retrieve();
        var articlePage = await contentItemRetriever.RetrieveWebPageById(
            context.WebPage.WebPageItemID,
            ArticlePage.CONTENT_TYPE_NAME,
            container => webPageQueryResultMapper.Map<ArticlePage>(container));

        var model = ArticlePageViewModel.GetViewModel(articlePage);
        return new TemplateResult(model);
    }
}
