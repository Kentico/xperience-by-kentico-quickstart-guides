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
	/// Represents a content item of type <see cref="Downloads"/>.
	/// </summary>
	public partial class Downloads
	{
		/// <summary>
		/// Code name of the content type.
		/// </summary>
		public const string CONTENT_TYPE_NAME = "TrainingGuides.Downloads";


		/// <summary>
		/// Represents system properties for a content item.
		/// </summary>
		public ContentItemFields SystemFields { get; set; }


		/// <summary>
		/// DownloadsHeading.
		/// </summary>
		public string DownloadsHeading { get; set; }


		/// <summary>
		/// DownloadsAssets.
		/// </summary>
		public IEnumerable<Asset> DownloadsAssets { get; set; }
	}
}