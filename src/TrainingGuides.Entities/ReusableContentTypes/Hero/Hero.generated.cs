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
using CMS.Websites;

namespace TrainingGuides
{
	/// <summary>
	/// Represents a content item of type <see cref="Hero"/>.
	/// </summary>
	public partial class Hero
	{
		/// <summary>
		/// Code name of the content type.
		/// </summary>
		public const string CONTENT_TYPE_NAME = "TrainingGuides.Hero";


		/// <summary>
		/// Represents system properties for a content item.
		/// </summary>
		public ContentItemFields SystemFields { get; set; }


		/// <summary>
		/// HeroHeader.
		/// </summary>
		public string HeroHeader { get; set; }


		/// <summary>
		/// HeroSubheader.
		/// </summary>
		public string HeroSubheader { get; set; }


		/// <summary>
		/// HeroMedia.
		/// </summary>
		public IEnumerable<Asset> HeroMedia { get; set; }


		/// <summary>
		/// HeroCallToAction.
		/// </summary>
		public string HeroCallToAction { get; set; }


		/// <summary>
		/// HeroBenefits.
		/// </summary>
		public IEnumerable<Benefit> HeroBenefits { get; set; }


		/// <summary>
		/// HeroTarget.
		/// </summary>
		public IEnumerable<WebPageRelatedItem> HeroTarget { get; set; }
	}
}