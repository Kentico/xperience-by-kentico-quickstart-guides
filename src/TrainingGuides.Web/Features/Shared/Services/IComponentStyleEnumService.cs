﻿using TrainingGuides.Web.Features.Shared.OptionProviders.CornerStyle;
using TrainingGuides.Web.Features.Shared.OptionsProviders.ColorScheme;

namespace TrainingGuides.Web.Features.Shared.Services;

public interface IComponentStyleEnumService
{
    IEnumerable<string> GetColorSchemeClasses(ColorSchemeOption colorScheme);

    IEnumerable<string> GetCornerStyleClasses(CornerStyleOption cornerStyle);

    CornerStyleOption GetCornerStyle(string cornerStyleString);

    ColorSchemeOption GetColorScheme(string colorSchemeString);
}
