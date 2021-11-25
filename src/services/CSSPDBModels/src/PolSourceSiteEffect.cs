namespace CSSPDBModels;

public partial class PolSourceSiteEffect : LastUpdate
{
    [Key]
    public int PolSourceSiteEffectID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10,17")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int PolSourceSiteOrInfrastructureTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int MWQMSiteTVItemID { get; set; }
    [CSSPMaxLength(250)]
    [CSSPAllowNull]
    public string PolSourceSiteEffectTermIDs { get; set; }
    [CSSPAllowNull]
    public string Comments { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? AnalysisDocumentTVItemID { get; set; }

    public PolSourceSiteEffect() : base()
    {
    }
}

