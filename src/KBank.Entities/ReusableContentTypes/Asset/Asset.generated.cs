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

namespace KBank
{
	/// <summary>
	/// Represents a content item of type <see cref="Asset"/>.
	/// </summary>
	public partial class Asset
	{
		/// <summary>
		/// Code name of the content type.
		/// </summary>
		public const string CONTENT_TYPE_NAME = "KBank.Asset";


		/// <summary>
		/// Represents system properties for a content item.
		/// </summary>
		public ContentItemFields SystemFields { get; set; }


		/// <summary>
		/// Description.
		/// </summary>
		public string Description { get; set; }


		/// <summary>
		/// AltText.
		/// </summary>
		public string AltText { get; set; }


		/// <summary>
		/// UseInternalOnly.
		/// </summary>
		public bool UseInternalOnly { get; set; }


		/// <summary>
		/// File.
		/// </summary>
		public ContentItemAsset File { get; set; }
	}
}