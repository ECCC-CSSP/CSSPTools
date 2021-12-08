namespace CSSPModels;

[NotMapped]
public partial class VarNameAndValue
{
    [CSSPMaxLength(200)]
    public string VariableName { get; set; }
    [CSSPMaxLength(300)]
    public string VariableValue { get; set; }

    public VarNameAndValue() : base()
    {
    }
}

