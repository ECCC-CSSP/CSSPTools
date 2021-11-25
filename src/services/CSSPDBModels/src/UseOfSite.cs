namespace CSSPDBModels;

public partial class UseOfSite : LastUpdate
{
    [Key]
    public int UseOfSiteID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "4,9,22")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int SiteTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int SubsectorTVItemID { get; set; }
    [CSSPEnumType]
    public TVTypeEnum TVType { get; set; }
    [CSSPRange(0, 1000)]
    public int Ordinal { get; set; }
    [CSSPRange(1980, 2050)]
    public int StartYear { get; set; }
    [CSSPRange(1980, 2050)]
    public int? EndYear { get; set; }
    public bool? UseWeight { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? Weight_perc { get; set; }
    public bool? UseEquation { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? Param1 { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? Param2 { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? Param3 { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? Param4 { get; set; }

    public UseOfSite() : base()
    {
    }
}

