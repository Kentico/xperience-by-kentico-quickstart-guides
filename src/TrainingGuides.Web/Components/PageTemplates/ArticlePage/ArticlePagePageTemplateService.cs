﻿using CMS.Websites;
using TrainingGuides.Web.Services.Content;
using Kentico.Content.Web.Mvc;

namespace TrainingGuides.Web.Components.PageTemplates;

public class ArticlePagePageTemplateService
{
    private readonly IWebPageDataContextRetriever webPageDataContextRetriver;
    private readonly IWebPageQueryResultMapper webPageQueryResultMapper;
    private readonly IContentItemRetrieverService<ArticlePage> contentItemRetriever;

    public ArticlePagePageTemplateService(IWebPageDataContextRetriever webPageDataContextRetriver, IWebPageQueryResultMapper webPageQueryResultMapper, IContentItemRetrieverService<ArticlePage> contentItemRetriever)
    {
        this.webPageDataContextRetriver = webPageDataContextRetriver;
        this.webPageQueryResultMapper = webPageQueryResultMapper;
        this.contentItemRetriever = contentItemRetriever;
    }


    public async Task<ArticlePageViewModel> GetTemplateModel()
    {
        var context = webPageDataContextRetriver.Retrieve();
        var articlePage = await contentItemRetriever.RetrieveWebPageById(
            context.WebPage.WebPageItemID,
            ArticlePage.CONTENT_TYPE_NAME,
            container => webPageQueryResultMapper.Map<ArticlePage>(container));
        return ArticlePageViewModel.GetViewModel(articlePage);
    }
}