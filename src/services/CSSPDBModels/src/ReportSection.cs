namespace CSSPDBModels;

public partial class ReportSection : LastUpdate
{
    [Key]
    public int ReportSectionID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID")]
    [CSSPForeignKey(TableName = "ReportTypes", FieldName = "ReportTypeID")]
    public int ReportTypeID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? TVItemID { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public LanguageEnum? Language { get; set; }
    [CSSPRange(0, 1000)]
    public int Ordinal { get; set; }
    public bool IsStatic { get; set; }
    [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID")]
    [CSSPForeignKey(TableName = "ReportSections", FieldName = "ReportSectionID")]
    public int? ParentReportSectionID { get; set; }
    [CSSPRange(1979, 2050)]
    public int? Year { get; set; }
    public bool Locked { get; set; }
    [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID")]
    [CSSPForeignKey(TableName = "ReportSections", FieldName = "ReportSectionID")]
    public int? TemplateReportSectionID { get; set; }
    [CSSPMaxLength(100)]
    [CSSPAllowNull]
    public string ReportSectionName { get; set; }
    [CSSPMaxLength(10000)]
    [CSSPAllowNull]
    public string ReportSectionText { get; set; }

    public ReportSection() : base()
    {
    }
}

