namespace CSSPDBModels;

public partial class ReportType : LastUpdate
{
    [Key]
    public int ReportTypeID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPEnumType]
    public TVTypeEnum TVType { get; set; }
    [CSSPEnumType]
    public FileTypeEnum FileType { get; set; }
    [CSSPMaxLength(100)]
    public string UniqueCode { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public LanguageEnum? Language { get; set; }
    [CSSPMaxLength(100)]
    [CSSPAllowNull]
    public string Name { get; set; }
    [CSSPMaxLength(1000)]
    [CSSPAllowNull]
    public string Description { get; set; }
    [CSSPMaxLength(100)]
    [CSSPAllowNull]
    public string StartOfFileName { get; set; }

    public ReportType() : base()
    {
    }
}

