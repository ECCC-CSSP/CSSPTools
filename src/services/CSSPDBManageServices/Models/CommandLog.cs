namespace ManageServices;

public partial class CommandLog
{
    [Key]
    public int CommandLogID { get; set; }
    [CSSPMaxLength(200)]
    public string AppName { get; set; }
    [CSSPMaxLength(200)]
    public string CommandName { get; set; }
    [CSSPMaxLength(10000000)]
    public string Error { get; set; }
    [CSSPMaxLength(10000000)]
    public string Log { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime DateTimeUTC { get; set; }

    public CommandLog() : base()
    {
    }
}

