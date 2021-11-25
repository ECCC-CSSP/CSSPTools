namespace CSSPDBModels;

public partial class SamplingPlanSubsectorSite : LastUpdate
{
    [Key]
    public int SamplingPlanSubsectorSiteID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "SamplingPlanSubsector", ExistPlurial = "s", ExistFieldID = "SamplingPlanSubsectorID")]
    [CSSPForeignKey(TableName = "SamplingPlanSubsectors", FieldName = "SamplingPlanSubsectorID")]
    public int SamplingPlanSubsectorID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int MWQMSiteTVItemID { get; set; }
    public bool IsDuplicate { get; set; }

    public SamplingPlanSubsectorSite() : base()
    {
    }
}

