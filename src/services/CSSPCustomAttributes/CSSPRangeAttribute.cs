namespace CSSPCustomAttributes;

/// <summary>
/// > [!NOTE]
/// > Custom validation attribute used to replace RangeAttribute
/// > <para>Used when generating some codes</para>
/// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
/// </summary>
/// <example>
///     <code>
///         [CSSPRange(pattern)]
///         public string FirstName { get; set; }
///     </code>
/// </example>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class CSSPRangeAttribute : RangeAttribute
{
    /// <summary>
    /// > [!NOTE]
    /// > Constructor
    /// </summary>
    public CSSPRangeAttribute(double minimum, double maximum) : base(minimum, maximum)
    {

    }
    /// <summary>
    /// > [!NOTE]
    /// > Constructor
    /// </summary>
    public CSSPRangeAttribute(int minimum, int maximum) : base(minimum, maximum)
    {

    }
    /// <summary>
    /// > [!NOTE]
    /// > Constructor
    /// </summary>
    public CSSPRangeAttribute(Type type, string minimum, string maximum) : base(type, minimum, maximum)
    {

    }
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

