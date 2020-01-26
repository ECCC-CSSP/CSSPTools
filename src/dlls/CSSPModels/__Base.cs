/*
 * Manually edited
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPModels
{
    #region Classes
    /// <param name="HasErrors">true if an error has occured, false if everything is ok</param>
    /// <param name="ValidationResults">Will contain the list of ValidationResults if an error has occured, otherwise the list will be empty</param>
    public partial class CSSPError
    {
        #region Properties for error handling
        /// <summary>
        /// > [!NOTE]
        /// > <para>Will be set to true if an error occurs during CRUD (Creating, Reading, Updating or Deleting)</para>
        /// </summary>
        [NotMapped]
        public bool HasErrors { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>Will hold all errors which were detected prior or during CRUD (Creating, Reading, Updating or Deleting)</para>
        /// </summary>
        [NotMapped]
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties for error handling

        #region Constructors
        /// <summary>
        /// > [!NOTE]
        /// > <para>Constructor will set the HasErrors field to false and ValidationResults with an empty list of ValidationResult)</para>
        /// </summary>
        public CSSPError()
        {
            HasErrors = false;
            ValidationResults = new List<ValidationResult>();
        }
        #endregion Constructors
    }
    public partial class LastUpdate : CSSPError
    {
        #region Properties in DB all tables
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>[[CSSPAfter](CSSPModels.CSSPAfterAttribute.html)(Year = 1980)]</para>
        /// </summary>
        /// <param name="LastUpdateDate_UTC">Every table within the database contains a field called LastUpdateDate_UTC which holds the last time the row of information was changed</param>
        [CSSPAfter(Year = 1980)]
        public DateTime LastUpdateDate_UTC { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > <para>**Other custom attributes**</para>
        /// > <para>**AllowableTVTypeList is of type [CSSPEnums.TVTypeEnum](CSSPEnums.TVTypeEnum.html)**</para>
        /// > <para>5 == Contact</para>
        /// > <para>[[CSSPExist](CSSPModels.CSSPExistAttribute.html)(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]</para>
        /// </summary>
        /// <param name="LastUpdateContactTVItemID">Every table within the database contains a field called LastUpdateContactTVItemID which holds the TVItemID of the last person who changed the row of information</param>
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
        public int LastUpdateContactTVItemID { get; set; }
        #endregion Properties in DB all tables

        #region Constructors
        public LastUpdate() : base()
        {

        }
        #endregion Constructors
    }
    #endregion Classes

    #region Attributes
    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used when generating code
    /// > <para>Used when generating some codes</para>
    /// > <para>Used on every field</para>
    /// > <para>**DescriptionEN** : Defines the text to be used when creating html (Angular) and documentation base text</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <example>
    ///     <code>
    ///         [CSSPDescriptionEN(DescriptionEN = @"First Name")]
    ///         public string FirstName { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPDescriptionENAttribute : ValidationAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Description text explaining the field withing html (Angular) and documentation
        /// </summary>
        public string DescriptionEN { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Not used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns>Not used</returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used when generating code
    /// > <para>Used when generating some codes</para>
    /// > <para>Used on every field</para>
    /// > <para>**DescriptionFR** : Defines the text to be used when creating html (Angular) and documentation base text</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <example>
    ///     <code>
    ///         [CSSPDescriptionFR(DescriptionEN = "Prénom")]
    ///         public string FirstName { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPDescriptionFRAttribute : ValidationAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Description text explaining the field withing html (Angular) and documentation
        /// </summary>
        public string DescriptionFR { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Not used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns>Not used</returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used when generating code
    /// > <para>Used when generating some codes</para>
    /// > <para>Used on every field</para>
    /// > <para>**DisplayEN** : Defines the text to be used when creating html (Angular) base text</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <example>
    ///     <code>
    ///         [CSSPDisplayEN(DisplayEN = "First Name")]
    ///         public string FirstName { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPDisplayENAttribute : ValidationAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Display text used in html (Angular) and documentation
        /// </summary>
        public string DisplayEN { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Not used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns>Not used</returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used when generating code
    /// > <para>Used when generating some codes</para>
    /// > <para>Used on every field</para>
    /// > <para>**DisplayFR** : Defines the text to be used when creating html (Angular) base text</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <example>
    ///     <code>
    ///         [CSSPDisplayFR(DisplayEN = "First Name")]
    ///         public string FirstName { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPDisplayFRAttribute : ValidationAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Display text used in html (Angular) and documentation
        /// </summary>
        public string DisplayFR { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Not used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns>Not used</returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used when generating code
    /// > <para>Used when generating [class]ServiceGenerated.cs and [class]ServiceTestGenerated.cs codes</para>
    /// > <para>Used on type: **DateTime**</para>
    /// > <para>DateTime only valid for years after **Year**</para>
    /// > <para>**Year** : Determine the year for which the DateTime has to be after</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <remarks>
    /// <para>Validation code produced</para>
    ///     <code>
    ///         if (mwqmSample.StartDate.Year &lt; 1980)
    ///         {
    ///             mwqmSample.HasErrors = true;
    ///             yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSampleStartDate, "1980"), new[] { "StartDate" });
    ///         }
    ///     </code>
    /// </remarks>
    /// <example>
    ///     <code>
    ///         [CSSPAfter(Year = 1980)]
    ///         public DateTime StartDate { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPAfterAttribute : ValidationAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Year for which the Date has to be after
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Not used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns>Not used</returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used when generating code
    /// > <para>Used when generating [class]ServiceGenerated.cs and [class]ServiceTestGenerated.cs codes</para>
    /// > <para>Used on type: **string** and **Enum**</para>
    /// > <para>Used when generating validation and testing on string properties when nullable</para>
    /// > <para>No parameter</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <remarks>
    /// <para>Validation code produced</para>
    ///     <code>
    ///         if (!string.IsNullOrWhiteSpace(address.StreetName) &amp;&amp; address.StreetName.Length > 200)
    ///         {
    ///             address.HasErrors = true;
    ///             yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AddressStreetName, "200"), new[] { "StreetName" });
    ///         }    
    ///     </code>
    /// </remarks>
    /// <example>
    ///     <code>
    ///         [StringLength(200)]
    ///         [CSSPAllowNull]
    ///         public string StreetName { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPAllowNullAttribute : ValidationAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// Not used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns>Not used</returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used when generating code
    /// > <para>Used when generating [class]ServiceGenerated.cs and [class]ServiceTestGenerated.cs codes</para>
    /// > <para>Used on type: **DateTime**</para>
    /// > <para>DateTime only valid if DateTime of **OtherField** is smaller or equal</para>
    /// > <para>**OtherField** : Determine the other field for which the DateTime has to be bigger</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <remarks>
    /// <para>Validation code produced</para>
    ///     <code>
    ///         if (appTask.StartDateTime_UTC > appTask.EndDateTime_UTC)
    ///         {
    ///             appTask.HasErrors = true;
    ///             yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.AppTaskEndDateTime_UTC, ModelsRes.AppTaskStartDateTime_UTC), new[] { ModelsRes.AppTaskEndDateTime_UTC });
    ///         }
    ///     </code>
    /// </remarks>
    /// <example>
    ///     <code>
    ///         [CSSPAfter(Year = 1980)]
    ///         public DateTime StartDateTime_UTC { get; set; }
    ///         [CSSPAfter(Year = 1980)]
    ///         [CSSPBigger(OtherField = "StartDateTime_UTC")]
    ///         public DateTime? EndDateTime_UTC { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPBiggerAttribute : ValidationAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Represent the other date field for which it has to be bigger
        /// </summary>
        public string OtherField { get; set; }

        /// <summary>
        /// > [!NOTE]
        /// > Not used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns>Not used</returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used when generating code
    /// > <para>Used when generating [class]ServiceGenerated.cs and [class]ServiceTestGenerated.cs codes</para>
    /// > <para>Used on type: Enumeration properties</para>
    /// > <para>Only valid if the Enum value is one of existing Enum</para>
    /// > <para>No parameter</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <remarks>
    /// <para>Validation code produced</para>
    ///     <code>
    ///         retStr = enums.AddressTypeOK(address.AddressType);
    ///         if (address.AddressType == AddressTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
    ///         {
    ///             address.HasErrors = true;
    ///             yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressAddressType), new[] { "AddressType" });
    ///         }
    ///     </code>
    /// </remarks>
    /// <example>
    ///     <code>
    ///         [CSSPEnumType]
    ///         public AddressTypeEnum AddressType { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPEnumTypeAttribute : ValidationAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Not used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used when generating code
    /// > <para>Used when generating [class]ServiceGenerated.cs and [class]ServiceTestGenerated.cs codes</para>
    /// > <para>Used on type: Enumeration properties</para>
    /// > <para>Used when generating Fill of services for enumeration</para>
    /// > <para>**EnumTypeName** : Enumeration name within CSSPEnums</para>
    /// > <para>**EnumType** : Property name</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <remarks>
    ///     <para>Validation code produced</para>
    ///     <code>
    ///         retStr = enums.AddressTypeOK(address.AddressType);
    ///         if (address.AddressType == AddressTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
    ///         {
    ///             address.HasErrors = true;
    ///             yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressAddressType), new[] { "AddressType" });
    ///         }
    ///     </code>
    /// </remarks>
    /// <example>
    ///     <code>
    ///         [CSSPEnumTypeText(EnumTypeName = "AddressTypeEnum", EnumType = "AddressType")]
    ///         public string AddressTypeText { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPEnumTypeTextAttribute : ValidationAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Enumeration name with CSSPEnums
        /// </summary>
        public string EnumTypeName { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Represent the property name
        /// </summary>
        public string EnumType { get; set; }

        /// <summary>
        /// > [!NOTE]
        /// > Not used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns>Not used</returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used when generating code
    /// > <para>Used when generating [class]ServiceGenerated.cs and [class]ServiceTestGenerated.cs codes</para>
    /// > <para>Used on type: int which represent the ID of database field key</para>
    /// > <para>**ExistTypeName** : Object Type text representing the name of the type</para>
    /// > <para>**ExistPlurial** : Plurial of the type which together creates the table name of the DB</para>
    /// > <para>**ExistFieldID** : Field ID of the table for which to compare with</para>
    /// > <para>**AllowableTVTypeList** : List of TVTypeEnum numbers separated by commas (only used with TVItems DB table)</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <remarks>
    /// <para>Validation code produced</para>
    /// <code>
    ///     TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == appTask.TVItemID select c).FirstOrDefault();
    ///     
    ///     if (TVItemTVItemID == null)
    ///     {
    ///         appTask.HasErrors = true;
    ///         yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskTVItemID, appTask.TVItemID.ToString()), new[] { "TVItemID" });
    ///     }
    ///     else
    ///     {
    ///         List&lt;TVTypeEnum&gt; AllowableTVTypes = new List&lt;TVTypeEnum&gt;()
    ///         {
    ///             TVTypeEnum.Root,
    ///             TVTypeEnum.Country,
    ///             TVTypeEnum.Province,
    ///             TVTypeEnum.Area,
    ///             TVTypeEnum.Sector,
    ///             TVTypeEnum.Subsector,
    ///             TVTypeEnum.ClimateSite,
    ///             TVTypeEnum.File,
    ///             TVTypeEnum.HydrometricSite,
    ///             TVTypeEnum.Infrastructure,
    ///             TVTypeEnum.MikeBoundaryConditionMesh,
    ///             TVTypeEnum.MikeBoundaryConditionWebTide,
    ///             TVTypeEnum.MikeScenario,
    ///             TVTypeEnum.MikeSource,
    ///             TVTypeEnum.Municipality,
    ///             TVTypeEnum.MWQMRun,
    ///             TVTypeEnum.MWQMSite,
    ///             TVTypeEnum.MWQMSiteSample,
    ///             TVTypeEnum.PolSourceSite,
    ///             TVTypeEnum.SamplingPlan,
    ///             TVTypeEnum.Spill,
    ///             TVTypeEnum.TideSite,
    ///             TVTypeEnum.VisualPlumesScenario,
    ///         };
    ///         if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
    ///         {
    ///             appTask.HasErrors = true;
    ///             yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppTaskTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite,VisualPlumesScenario"), new[] { "TVItemID" });
    ///         }
    ///     }
    /// </code>
    /// </remarks>
    /// <example>
    ///     <code>
    ///         [CSSPExist(ExistTypeName = "AppTask", ExistPlurial = "s", ExistFieldID = "AppTaskID")]
    ///         public int AppTaskID { get; set; }
    ///     </code>
    ///     or
    ///     <code>
    ///         [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
    ///         public int TVItemID { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPExistAttribute : ValidationAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Type text representing the name of the type
        /// </summary>
        public string ExistTypeName { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Plurial of the type which together creates the table name of the DB
        /// </summary>
        public string ExistPlurial { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Field ID of the table for which to compare with
        /// </summary>
        public string ExistFieldID { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > List of TVTypeEnum numbers separated by commas (only used with TVItems DB table)
        /// </summary>
        public string AllowableTVTypeList { get; set; }

        /// <summary>
        /// > [!NOTE]
        /// > No used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns>Not used</returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used when generating code
    /// > <para>Used when generating [class]ServiceGenerated.cs and [class]ServiceTestGenerated.cs codes</para>
    /// > <para>Used on various types</para>
    /// > <para>**FillTypeName** : Object Type text representing the name of the type</para>
    /// > <para>**FillPlurial** : Plurial of the type which together creates the table name of the DB</para>
    /// > <para>**FillFieldID** : Field ID of the table for which to compare with</para>
    /// > <para>**FillEqualField** : Field name/value to compare with DB table</para>
    /// > <para>**FillReturnField** : Field name/value to return</para>
    /// > <para>**FillNeedLanguage** : If true, a language comparision will also be included</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <remarks>
    /// <para>Validation code produced</para>
    ///     <code>
    ///         private List&lt;Address&gt; FillAddress(IQueryable&lt;Address&gt; addressQuery)
    ///         {
    ///             List&lt;Address&gt; AddressList = 
    ///                 (from c in addressQuery
    ///                     let ParentTVItemID = (from cl in db.TVItems
    ///                                           where cl.TVItemID == c.AddressTVItemID
    ///                                           select cl.ParentID).FirstOrDefault()
    ///                     let AddressTVText = (from cl in db.TVItemLanguages
    ///                                          where cl.TVItemID == c.AddressTVItemID
    ///                                          &amp;&amp; cl.Language == LanguageRequest
    ///                                          select cl.TVText).FirstOrDefault()
    ///                     let CountryTVText = (from cl in db.TVItemLanguages
    ///                                          where cl.TVItemID == c.CountryTVItemID
    ///                                          &amp;&amp; cl.Language == LanguageRequest
    ///                                          select cl.TVText).FirstOrDefault()
    ///                     let ProvinceTVText = (from cl in db.TVItemLanguages
    ///                                           where cl.TVItemID == c.ProvinceTVItemID
    ///                                           &amp;&amp; cl.Language == LanguageRequest
    ///                                           select cl.TVText).FirstOrDefault()
    ///                     let MunicipalityTVText = (from cl in db.TVItemLanguages
    ///                                               where cl.TVItemID == c.MunicipalityTVItemID
    ///                                               &amp;&amp; cl.Language == LanguageRequest
    ///                                               select cl.TVText).FirstOrDefault()
    ///                     let LastUpdateContactTVText = (from cl in db.TVItemLanguages
    ///                                                    where cl.TVItemID == c.LastUpdateContactTVItemID
    ///                                                    &amp;&amp; cl.Language == LanguageRequest
    ///                                                    select cl.TVText).FirstOrDefault()
    ///                     select new Address
    ///                     {
    ///                         AddressID = c.AddressID,
    ///                         AddressTVItemID = c.AddressTVItemID,
    ///                         AddressType = c.AddressType,
    ///                         CountryTVItemID = c.CountryTVItemID,
    ///                         ProvinceTVItemID = c.ProvinceTVItemID,
    ///                         MunicipalityTVItemID = c.MunicipalityTVItemID,
    ///                         StreetName = c.StreetName,
    ///                         StreetNumber = c.StreetNumber,
    ///                         StreetType = c.StreetType,
    ///                         PostalCode = c.PostalCode,
    ///                         GoogleAddressText = c.GoogleAddressText,
    ///                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
    ///                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
    ///                         ParentTVItemID = ParentTVItemID,
    ///                         AddressTVText = AddressTVText,
    ///                         CountryTVText = CountryTVText,
    ///                         ProvinceTVText = ProvinceTVText,
    ///                         MunicipalityTVText = MunicipalityTVText,
    ///                         LastUpdateContactTVText = LastUpdateContactTVText,
    ///                         ValidationResults = null,
    ///                     }).ToList();
    ///         
    ///             Enums enums = new Enums(LanguageRequest);
    ///         
    ///             foreach (Address address in AddressList)
    ///             {
    ///                 address.AddressTypeText = enums.GetEnumText_AddressTypeEnum(address.AddressType);
    ///                 address.StreetTypeText = enums.GetEnumText_StreetTypeEnum(address.StreetType);
    ///             }
    ///         
    ///             return AddressList;
    ///         }
    ///     </code>
    /// </remarks>
    /// <example>
    ///     <code>
    ///         [NotMapped]
    ///         [StringLength(200)]
    ///         [CSSPAllowNull]
    ///         [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "AddressTVItemID", FillReturnField = "TVText", FillNeedLanguage = true)]
    ///         public string AddressTVText { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPFillAttribute : ValidationAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Object Type text representing the name of the type
        /// </summary>
        public string FillTypeName { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Plurial of the type which together creates the table name of the DB
        /// </summary>
        public string FillPlurial { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Field ID of the table for which to compare with
        /// </summary>
        public string FillFieldID { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Field name/value to compare with DB table
        /// </summary>
        public string FillEqualField { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > Field name/value to return
        /// </summary>
        public string FillReturnField { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > If true, a language comparision will also be included
        /// </summary>
        public bool FillNeedLanguage { get; set; }
        /// <summary>
        /// > [!NOTE]
        /// > If true, a list of items will be included otherwise a single item
        /// </summary>
        public bool FillIsList { get; set; }

        /// <summary>
        /// > [!NOTE]
        /// > No used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns>Not used</returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }
    #endregion Attributes
}
