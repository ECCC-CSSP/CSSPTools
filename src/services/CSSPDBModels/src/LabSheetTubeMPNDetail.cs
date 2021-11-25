namespace CSSPDBModels;

public partial class LabSheetTubeMPNDetail : LastUpdate
{
    [Key]
    public int LabSheetTubeMPNDetailID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "LabSheetDetail", ExistPlurial = "s", ExistFieldID = "LabSheetDetailID")]
    [CSSPForeignKey(TableName = "LabSheetDetails", FieldName = "LabSheetDetailID")]
    public int LabSheetDetailID { get; set; }
    [CSSPRange(0, 1000)]
    public int Ordinal { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int MWQMSiteTVItemID { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? SampleDateTime { get; set; }
    [CSSPRange(1, 10000000)]
    public int? MPN { get; set; }
    [CSSPRange(0, 5)]
    public int? Tube10 { get; set; }
    [CSSPRange(0, 5)]
    public int? Tube1_0 { get; set; }
    [CSSPRange(0, 5)]
    public int? Tube0_1 { get; set; }
    [CSSPRange(0.0D, 40.0D)]
    public double? Salinity { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? Temperature { get; set; }
    [CSSPMaxLength(10)]
    [CSSPAllowNull]
    public string ProcessedBy { get; set; }
    [CSSPEnumType]
    public SampleTypeEnum SampleType { get; set; }
    [CSSPMaxLength(250)]
    [CSSPAllowNull]
    public string SiteComment { get; set; }

    public LabSheetTubeMPNDetail() : base()
    {
    }
}

