﻿using System.ComponentModel;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Websites.FormAnnotations;
using TrainingGuides.Web.Features.Shared.OptionsProviders;
using TrainingGuides.Web.Features.Shared.OptionsProviders.Heading;

namespace TrainingGuides.Web.Features.Products.Widgets.ProductComparator;
public class ProductComparatorWidgetProperties : IWidgetProperties
{
    [WebPageSelectorComponent(Label = "Selected products", Order = 1, MaximumPages = 0, Sortable = true, ItemModifierType = typeof(ProductComparatorWidgetItemModifier))]
    public IEnumerable<WebPageRelatedItem> Products { get; set; } = null!;

    [TextInputComponent(Label = "Comparator heading", Order = 2)]
    public string ComparatorHeading { get; set; } = null!;

    [DropDownComponent(
        Label = "Heading type",
        DataProviderType = typeof(ProductComparatorHeadingTypeOptionsProvider),
        Order = 3
    )]
    public string HeadingType { get; set; } = HeadingTypeOption.Auto.ToString();

    [DropDownComponent(
        Label = "Heading margin",
        DataProviderType = typeof(DropdownEnumOptionsProvider<HeadingMarginOption>),
        Order = 4
    )]
    public string HeadingMargin { get; set; } = HeadingMarginOption.Default.ToString();

    [TextInputComponent(Label = "CTA", Order = 5)]
    public string CallToAction { get; set; } = null!;

    [CheckBoxComponent(Label = "Show short description", Order = 6)]
    public bool ShowShortDescription { get; set; }

    [CheckBoxComponent(Label = "Show price", Order = 7)]
    public bool ShowPrice { get; set; }
}

public class ProductComparatorHeadingTypeOptionsProvider : HeadingTypeOptionsProvider
{
    public ProductComparatorHeadingTypeOptionsProvider() : base(new[] {
        HeadingTypeOption.Auto,
        HeadingTypeOption.H2,
        HeadingTypeOption.H3,
        HeadingTypeOption.H4
        })
    { }
}

public enum HeadingMarginOption
{
    [Description("Default")]
    Default,
    [Description("Small")]
    Small,
    [Description("Large")]
    Large
}
