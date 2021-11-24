namespace CSSPCustomAttributes;

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

