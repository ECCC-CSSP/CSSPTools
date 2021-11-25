namespace CSSPDBModels;

public partial class RainExceedanceClimateSite : LastUpdate
{
    [Key]
    public int RainExceedanceClimateSiteID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "75")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int RainExceedanceTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "4")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int ClimateSiteTVItemID { get; set; }

    public RainExceedanceClimateSite() : base()
    {
    }
}

