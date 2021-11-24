namespace CSSPCustomAttributes;

/// <summary>
/// > [!NOTE]
/// > Custom validation attribute used to replace MaxLengthAttribute
/// > <para>Used when generating some codes</para>
/// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
/// </summary>
/// <example>
///     <code>
///         [CSSPMinLength(6)]
///         public string FirstName { get; set; }
///     </code>
/// </example>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class CSSPMaxLengthAttribute : MaxLengthAttribute
{
    /// <summary>
    /// > [!NOTE]
    /// > Constructor
    /// </summary>
    public CSSPMaxLengthAttribute(int length) : base(length)
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

