namespace CSSPDBModels;

public partial class AppErrLog : LastUpdate
{
    [Key]
    public int AppErrLogID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPMaxLength(100)]
    public string Tag { get; set; }
    [CSSPRange(1, -1)]
    public int LineNumber { get; set; }
    public string Source { get; set; }
    public string Message { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime DateTime_UTC { get; set; }

    public AppErrLog() : base()
    {
    }
}
