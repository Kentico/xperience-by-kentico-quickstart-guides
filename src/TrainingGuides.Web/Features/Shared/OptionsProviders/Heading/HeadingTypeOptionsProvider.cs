﻿namespace TrainingGuides.Web.Features.Shared.OptionsProviders.Heading;

public class HeadingTypeOptionsProvider : DropdownEnumOptionsProvider<HeadingTypeOption>
{
    public HeadingTypeOptionsProvider(IEnumerable<HeadingTypeOption>? subset = null) : base(subset)
    {
    }

    public override HeadingTypeOption? Parse(string value) => base.Parse(value) ?? HeadingTypeOption.Auto;
}