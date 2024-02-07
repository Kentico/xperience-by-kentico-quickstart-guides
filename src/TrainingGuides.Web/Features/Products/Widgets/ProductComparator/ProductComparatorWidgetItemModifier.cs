﻿using Kentico.Xperience.Admin.Websites;

namespace TrainingGuides.Web.Features.Products.Widgets.ProductComparator;

public class ProductComparatorWidgetItemModifier : IWebPagePanelItemModifier
{
    public WebPagePanelItem Modify(WebPagePanelItem webPagePanelItem,
        WebPagePanelItemModifierParameters webPagePanelItemModifierParameters)
    {
        webPagePanelItem.SelectableOption.Selectable = true;
        return webPagePanelItem;
    }
}
