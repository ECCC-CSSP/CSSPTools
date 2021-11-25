namespace CSSPDBModels;

public partial class SamplingPlanSubsector : LastUpdate
{
    [Key]
    public int SamplingPlanSubsectorID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID")]
    [CSSPForeignKey(TableName = "SamplingPlans", FieldName = "SamplingPlanID")]
    public int SamplingPlanID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int SubsectorTVItemID { get; set; }

    public SamplingPlanSubsector() : base()
    {
    }
}

