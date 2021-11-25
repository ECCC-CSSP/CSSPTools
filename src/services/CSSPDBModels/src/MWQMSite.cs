namespace CSSPDBModels;

public partial class MWQMSite : LastUpdate
{
    [Key]
    public int MWQMSiteID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int MWQMSiteTVItemID { get; set; }
    [CSSPMaxLength(8)]
    public string MWQMSiteNumber { get; set; }
    [CSSPMaxLength(200)]
    public string MWQMSiteDescription { get; set; }
    [CSSPEnumType]
    public MWQMSiteLatestClassificationEnum MWQMSiteLatestClassification { get; set; }
    [CSSPRange(0, 1000)]
    public int Ordinal { get; set; }

    public MWQMSite() : base()
    {
    }
}

