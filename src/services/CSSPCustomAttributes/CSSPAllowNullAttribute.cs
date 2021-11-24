namespace CSSPCustomAttributes;

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
///             yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AddressStreetName, "200"), new[] { "StreetName" });
///         }    
///     </code>
/// </remarks>
/// <example>
///     <code>
///         [CSSPMaxLength(200)]
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

