namespace CSSPCustomAttributes;

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

