namespace CSSPCustomAttributes;

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

