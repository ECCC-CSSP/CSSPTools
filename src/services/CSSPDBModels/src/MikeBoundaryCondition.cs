namespace CSSPDBModels;

public partial class MikeBoundaryCondition : LastUpdate
{
    [Key]
    public int MikeBoundaryConditionID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "12,11")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int MikeBoundaryConditionTVItemID { get; set; }
    [CSSPMaxLength(100)]
    public string MikeBoundaryConditionCode { get; set; }
    [CSSPMaxLength(100)]
    public string MikeBoundaryConditionName { get; set; }
    [CSSPRange(1.0D, 100000.0D)]
    public double MikeBoundaryConditionLength_m { get; set; }
    [CSSPMaxLength(100)]
    public string MikeBoundaryConditionFormat { get; set; }
    [CSSPEnumType]
    public MikeBoundaryConditionLevelOrVelocityEnum MikeBoundaryConditionLevelOrVelocity { get; set; }
    [CSSPEnumType]
    public WebTideDataSetEnum WebTideDataSet { get; set; }
    [CSSPRange(0, 1000)]
    public int NumberOfWebTideNodes { get; set; }
    public string WebTideDataFromStartToEndDate { get; set; }
    [CSSPEnumType]
    public TVTypeEnum TVType { get; set; }

    public MikeBoundaryCondition() : base()
    {
    }
}

