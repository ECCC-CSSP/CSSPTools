namespace CSSPDBModels;

public partial class TVFile : LastUpdate
{
    public int TVFileID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int TVFileTVItemID { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public TVTypeEnum? TemplateTVType { get; set; }
    [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID")]
    [CSSPForeignKey(TableName = "ReportTypes", FieldName = "ReportTypeID")]
    public int? ReportTypeID { get; set; }
    [CSSPAllowNull]
    public string Parameters { get; set; }
    [CSSPRange(1980, 2050)]
    public int? Year { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPEnumType]
    public FilePurposeEnum FilePurpose { get; set; }
    [CSSPEnumType]
    public FileTypeEnum FileType { get; set; }
    [CSSPRange(0, 100000000)]
    public int FileSize_kb { get; set; }
    [CSSPAllowNull]
    public string FileInfo { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime FileCreatedDate_UTC { get; set; }
    public bool? FromWater { get; set; }
    [CSSPMaxLength(250)]
    [CSSPAllowNull]
    public string ClientFilePath { get; set; }
    [CSSPMaxLength(250)]
    public string ServerFileName { get; set; }
    [CSSPMaxLength(250)]
    public string ServerFilePath { get; set; }

    public TVFile() : base()
    {
    }
}

