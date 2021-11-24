namespace CSSPCustomAttributes;

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

