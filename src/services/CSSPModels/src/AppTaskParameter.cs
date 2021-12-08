namespace CSSPModels;

[NotMapped]
public partial class AppTaskParameter
{
    [CSSPMaxLength(255)]
    public string Name { get; set; }
    [CSSPMaxLength(255)]
    public string Value { get; set; }

    public AppTaskParameter() : base()
    {
    }
}

