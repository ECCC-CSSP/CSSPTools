namespace CSSPDBModels;

public partial class TideSite : LastUpdate
{
    [Key]
    public int TideSiteID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "22")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int TideSiteTVItemID { get; set; }
    [CSSPMaxLength(100)]
    public string TideSiteName { get; set; }
    [CSSPMaxLength(2)]
    [CSSPMinLength(2)]
    public string Province { get; set; }
    [CSSPRange(0, 10000)]
    public int sid { get; set; }
    [CSSPRange(0, 10000)]
    public int Zone { get; set; }

    public TideSite() : base()
    {
    }
}

