namespace CSSPDBModels;

public partial class MWQMSample : LastUpdate
{
    [Key]
    public int MWQMSampleID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int MWQMSiteTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "31")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int MWQMRunTVItemID { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime SampleDateTime_Local { get; set; }
    [CSSPMaxLength(6)]
    [CSSPAllowNull]
    public string TimeText { get; set; }
    [CSSPRange(0.0D, 1000.0D)]
    public double? Depth_m { get; set; }
    [CSSPRange(0, 10000000)]
    public int FecCol_MPN_100ml { get; set; }
    [CSSPRange(0.0D, 40.0D)]
    public double? Salinity_PPT { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? WaterTemp_C { get; set; }
    [CSSPRange(0.0D, 14.0D)]
    public double? PH { get; set; }
    [CSSPMaxLength(50)]
    public string SampleTypesText { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public SampleTypeEnum? SampleType_old { get; set; }
    [CSSPRange(0, 5)]
    public int? Tube_10 { get; set; }
    [CSSPRange(0, 5)]
    public int? Tube_1_0 { get; set; }
    [CSSPRange(0, 5)]
    public int? Tube_0_1 { get; set; }
    [CSSPMaxLength(10)]
    [CSSPAllowNull]
    public string ProcessedBy { get; set; }
    public bool UseForOpenData { get; set; }

    public MWQMSample() : base()
    {
    }
}

