namespace CSSPCustomAttributes;


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
///         [CSSPMaxLength(200)]
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

