using System;
using System.Data;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;

using CMS;
using CMS.DataEngine;
using CMS.Helpers;
using TrainingGuides.ProjectSettings;

[assembly: RegisterObjectType(typeof(SeoSettingsInfo), SeoSettingsInfo.OBJECT_TYPE)]

namespace TrainingGuides.ProjectSettings
{
    /// <summary>
    /// Data container class for <see cref="SeoSettingsInfo"/>.
    /// </summary>
    [Serializable]
    public partial class SeoSettingsInfo : AbstractInfo<SeoSettingsInfo, IInfoProvider<SeoSettingsInfo>>, IInfoWithId
    {
        /// <summary>
        /// Object type.
        /// </summary>
        public const string OBJECT_TYPE = "trainingguides.seosettings";


        /// <summary>
        /// Type information.
        /// </summary>
#warning "You will need to configure the type info."
        public static readonly ObjectTypeInfo TYPEINFO = new ObjectTypeInfo(typeof(IInfoProvider<SeoSettingsInfo>), OBJECT_TYPE, "TrainingGuides.SeoSettings", "SeoSettingsID", null, null, null, null, null, null, null)
        {
            TouchCacheDependencies = true,
            DependsOn = new List<ObjectDependency>()
            {
                new ObjectDependency("SeoSettingsWebChannelSettingId", "trainingguides.webchannelsettings", ObjectDependencyEnum.Required),
            },
        };


        /// <summary>
        /// Seo settings ID.
        /// </summary>
        [DatabaseField]
        public virtual int SeoSettingsID
        {
            get => ValidationHelper.GetInteger(GetValue(nameof(SeoSettingsID)), 0);
            set => SetValue(nameof(SeoSettingsID), value);
        }


        /// <summary>
        /// Seo settings robots.
        /// </summary>
        [DatabaseField]
        public virtual string SeoSettingsRobots
        {
            get => ValidationHelper.GetString(GetValue(nameof(SeoSettingsRobots)), String.Empty);
            set => SetValue(nameof(SeoSettingsRobots), value);
        }


        /// <summary>
        /// Seo settings web channel setting id.
        /// </summary>
        [DatabaseField]
        public virtual int SeoSettingsWebChannelSettingId
        {
            get => ValidationHelper.GetInteger(GetValue(nameof(SeoSettingsWebChannelSettingId)), 0);
            set => SetValue(nameof(SeoSettingsWebChannelSettingId), value);
        }


        /// <summary>
        /// Deletes the object using appropriate provider.
        /// </summary>
        protected override void DeleteObject()
        {
            Provider.Delete(this);
        }


        /// <summary>
        /// Updates the object using appropriate provider.
        /// </summary>
        protected override void SetObject()
        {
            Provider.Set(this);
        }


        /// <summary>
        /// Constructor for de-serialization.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected SeoSettingsInfo(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }


        /// <summary>
        /// Creates an empty instance of the <see cref="SeoSettingsInfo"/> class.
        /// </summary>
        public SeoSettingsInfo()
            : base(TYPEINFO)
        {
        }


        /// <summary>
        /// Creates a new instances of the <see cref="SeoSettingsInfo"/> class from the given <see cref="DataRow"/>.
        /// </summary>
        /// <param name="dr">DataRow with the object data.</param>
        public SeoSettingsInfo(DataRow dr)
            : base(TYPEINFO, dr)
        {
        }
    }
}