﻿using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using TrainingGuides.Web.Features.Products.Widgets.ProductComparator;
using TrainingGuides.Web.Features.Shared.Models;
using TrainingGuides.Web.Features.Shared.Services;

[assembly:
    RegisterWidget(ProductComparatorWidgetComponent.IDENTIFIER, typeof(ProductComparatorWidgetComponent),
        "Product comparator",
        typeof(ProductComparatorWidgetProperties), Description = "Displays the products comparison.",
        IconClass = "icon-ribbon")]

namespace TrainingGuides.Web.Features.Products.Widgets.ProductComparator;

public class ProductComparatorWidgetComponent : ViewComponent
{
    public const string IDENTIFIER = "Kbank.ProductComparatorWidget";

    private readonly IContentItemRetrieverService<ProductPage> productRetrieverService;
    private readonly IWebPageQueryResultMapper webPageQueryResultMapper;
    private readonly IWebPageUrlRetriever webPageUrlRetriever;
    private readonly IHttpRequestService httpRequestService;

    public ProductComparatorWidgetComponent(IContentItemRetrieverService<ProductPage> productRetrieverService,
        IWebPageQueryResultMapper webPageQueryResultMapper,
        IWebPageUrlRetriever webPageUrlRetriever,
        IHttpRequestService httpRequestService)
    {
        this.productRetrieverService = productRetrieverService;
        this.webPageQueryResultMapper = webPageQueryResultMapper;
        this.webPageUrlRetriever = webPageUrlRetriever;
        this.httpRequestService = httpRequestService;
    }

    public async Task<ViewViewComponentResult> InvokeAsync(ProductComparatorWidgetProperties properties,
        CancellationToken cancellationToken)
    {
        var guids = properties.Products?.Select(i => i.WebPageGuid).ToList() ?? [];

        var model = new ProductComparatorWidgetViewModel()
        {
            Products = [],
            GroupedFeatures = [],
            ComparatorHeading = properties.ComparatorHeading,
            HeadingType = new HeadingTypeOptionsProvider().Parse(properties.HeadingType)!.Value,
            HeadingMargin = properties.HeadingMargin ?? "default",
            ShowShortDescription = properties.ShowShortDescription,
            CheckboxIconUrl = $"{httpRequestService.GetBaseUrl()}/assets/img/icons.svg#check"
        };

        foreach (var guid in guids)
        {
            var product = await GetProduct(guid, properties, cancellationToken);

            if (product != null)
            {
                model.Products.Add(product);

                model.GroupedFeatures.AddRange(product.Features.Where(i => i.ShowInComparator)
                    .Select(feature => new KeyValuePair<string, HtmlString>(feature.Key, feature.Label)));
            }
        }

        model.GroupedFeatures = model.GroupedFeatures.DistinctBy(item => item.Key).ToList();

        return View("~/Features/Products/Products/Widgets/ProductComparatorWidget/_ProductComparatorWidget.cshtml", model);
    }

    private async Task<ProductViewModel?> GetProduct(Guid guid, ProductComparatorWidgetProperties properties, CancellationToken cancellationToken)
    {
        var productPage = await productRetrieverService.RetrieveWebPageByGuid(
                            guid,
                            ProductPage.CONTENT_TYPE_NAME,
                            webPageQueryResultMapper.Map<ProductPage>,
                            3);

        if (productPage == null)
            return null;

        var product = productPage.ProductPageProduct.FirstOrDefault();

        if (product == null)
            return null;

        var linkComponent = new LinkViewModel()
        {
            Page = webPageUrlRetriever.Retrieve(productPage, cancellationToken).Result.RelativePath
        };

        var model = new ProductViewModel()
        {
            Name = new(product.ProductName),
            ShortDescription = new(product.ProductShortDescription),
            Url = linkComponent.Page,
            Features = product.ProductFeatures.Select(ProductFeaturesViewModel.GetViewModel).ToList(),
            Link = linkComponent,
            CallToAction = !string.IsNullOrEmpty(properties.CallToAction)
                ? properties.CallToAction
                : string.Empty

        };

        return model;
    }
}
