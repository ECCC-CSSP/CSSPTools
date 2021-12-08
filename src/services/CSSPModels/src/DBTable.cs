namespace CSSPModels;

[NotMapped]
public partial class DBTable
{
    [CSSPMaxLength(200)]
    [CSSPMinLength(1)]
    public string TableName { get; set; }
    [CSSPMaxLength(3)]
    [CSSPMinLength(1)]
    public string Plurial { get; set; }

    public DBTable() : base()
    {
    }
}

