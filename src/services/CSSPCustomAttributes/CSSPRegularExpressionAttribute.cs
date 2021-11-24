namespace CSSPCustomAttributes;

/// <summary>
/// > [!NOTE]
/// > Custom validation attribute used to replace RegularExpressionAttribute
/// > <para>Used when generating some codes</para>
/// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
/// </summary>
/// <example>
///     <code>
///         [CSSPRegularExpression(pattern)]
///         public string FirstName { get; set; }
///     </code>
/// </example>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class CSSPRegularExpressionAttribute : RegularExpressionAttribute
{
    /// <summary>
    /// > [!NOTE]
    /// > Constructor
    /// </summary>
    public CSSPRegularExpressionAttribute(string pattern) : base(pattern)
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
