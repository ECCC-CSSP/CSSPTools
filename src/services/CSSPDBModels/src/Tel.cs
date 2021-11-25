namespace CSSPDBModels;

public partial class Tel : LastUpdate
{
    [Key]
    public int TelID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "21")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int TelTVItemID { get; set; }
    [CSSPMaxLength(50)]
    public string TelNumber { get; set; }
    [CSSPEnumType]
    public TelTypeEnum TelType { get; set; }

    public Tel() : base()
    {
    }
}

