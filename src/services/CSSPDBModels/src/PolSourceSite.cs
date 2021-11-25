namespace CSSPDBModels;

public partial class PolSourceSite : LastUpdate
{
    [Key]
    public int PolSourceSiteID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "17")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int PolSourceSiteTVItemID { get; set; }
    [CSSPMaxLength(50)]
    [CSSPAllowNull]
    public string Temp_Locator_CanDelete { get; set; }
    [CSSPRange(0, 1000)]
    public int? Oldsiteid { get; set; }
    [CSSPRange(0, 1000)]
    public int? Site { get; set; }
    [CSSPRange(0, 1000)]
    public int? SiteID { get; set; }
    public bool IsPointSource { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public PolSourceInactiveReasonEnum? InactiveReason { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "2")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? CivicAddressTVItemID { get; set; }

    public PolSourceSite() : base()
    {
    }
}

