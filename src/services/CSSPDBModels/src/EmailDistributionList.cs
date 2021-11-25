namespace CSSPDBModels;

public partial class EmailDistributionList : LastUpdate
{
    [Key]
    public int EmailDistributionListID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "6")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int ParentTVItemID { get; set; }
    [CSSPRange(0, 1000)]
    public int Ordinal { get; set; }

    public EmailDistributionList() : base()
    {
    }
}

