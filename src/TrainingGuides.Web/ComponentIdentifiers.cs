﻿using TrainingGuides.Web.Features.LandingPages.Widgets.HeroBanner;
using TrainingGuides.Web.Features.Activities.Widgets.PageLike;
using TrainingGuides.Web.Features.DataProtection.Widgets.CookiePreferences;
using TrainingGuides.Web.Features.LandingPages.Widgets.CallToAction;
using TrainingGuides.Web.Features.Shared.Sections.FormColumn;
using TrainingGuides.Web.Features.Shared.Sections.SingleColumn;
using TrainingGuides.Web.Features.Products.Widgets.ProductComparator;
using TrainingGuides.Web.Features.Html.Widgets.HtmlCode;
using TrainingGuides.Web.Features.Articles.Widgets.ArticleList;

namespace TrainingGuides.Web;

public static class ComponentIdentifiers
{
    public static class Sections
    {
        public const string SINGLE_COLUMN = SingleColumnSectionViewComponent.IDENTIFIER;
        public const string FORM_COLUMN = FormColumnSectionViewComponent.IDENTIFIER;
        public const string FORM_COLUMN_CONSENT = FormColumnSectionViewComponent.IDENTIFIER;
    }

    public static class Widgets
    {
        public const string PAGE_LIKE = PageLikeWidgetViewComponent.IDENTIFIER;
        public const string COOKIE_PREFERENCES = CookiePreferencesWidgetViewComponent.IDENTIFIER;
        public const string CALL_TO_ACTION = CallToActionWidgetViewComponent.IDENTIFIER;
        public const string HERO_BANNER = HeroBannerWidgetViewComponent.IDENTIFIER;
        public const string PRODUCT_COMPARATOR = ProductComparatorWidgetViewComponent.IDENTIFIER;
        public const string HTML_CODE = HtmlCodeWidgetViewComponent.IDENTIFIER;
        public const string ARTICLE_LIST = ArticleListWidgetViewComponent.IDENTIFIER;
    }
}
