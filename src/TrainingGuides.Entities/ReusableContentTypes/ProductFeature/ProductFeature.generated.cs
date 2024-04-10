//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at https://docs.xperience.io/.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CMS.ContentEngine;

namespace TrainingGuides
{
	/// <summary>
	/// Represents a content item of type <see cref="ProductFeature"/>.
	/// </summary>
	[RegisterContentTypeMapping(CONTENT_TYPE_NAME)]
	public partial class ProductFeature : IContentItemFieldsSource
	{
		/// <summary>
		/// Code name of the content type.
		/// </summary>
		public const string CONTENT_TYPE_NAME = "TrainingGuides.ProductFeature";


		/// <summary>
		/// Represents system properties for a content item.
		/// </summary>
		[SystemField]
		public ContentItemFields SystemFields { get; set; }


		/// <summary>
		/// ProductFeatureLabel.
		/// </summary>
		public string ProductFeatureLabel { get; set; }


		/// <summary>
		/// ProductFeatureKey.
		/// </summary>
		public string ProductFeatureKey { get; set; }


		/// <summary>
		/// ProductFeatureValueType.
		/// </summary>
		public string ProductFeatureValueType { get; set; }


		/// <summary>
		/// ProductFeatureValue.
		/// </summary>
		public string ProductFeatureValue { get; set; }


		/// <summary>
		/// ProductFeaturePrice.
		/// </summary>
		public decimal ProductFeaturePrice { get; set; }


		/// <summary>
		/// ProductFeatureIncluded.
		/// </summary>
		public bool ProductFeatureIncluded { get; set; }


		/// <summary>
		/// ProductFeatureShowInComparator.
		/// </summary>
		public string ProductFeatureShowInComparator { get; set; }
	}
}