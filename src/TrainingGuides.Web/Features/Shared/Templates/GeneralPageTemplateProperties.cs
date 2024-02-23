﻿using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace TrainingGuides.Web.Features.Shared;

public class GeneralPageTemplateProperties : IPageTemplateProperties
{
    public string ColumnLayout { get; set; }
    public string ColorScheme { get; set; }
    public string CornerType { get; set; }

}

