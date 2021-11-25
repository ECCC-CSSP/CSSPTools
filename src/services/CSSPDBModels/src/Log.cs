namespace CSSPDBModels;

public partial class Log : LastUpdate
{
    [Key]
    public int LogID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPMaxLength(50)]
    public string TableName { get; set; }
    [CSSPRange(1, -1)]
    public int ID { get; set; }
    [CSSPEnumType]
    public LogCommandEnum LogCommand { get; set; }
    public string Information { get; set; }

    public Log() : base()
    {
    }
}

