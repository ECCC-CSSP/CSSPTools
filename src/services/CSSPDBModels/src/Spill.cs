namespace CSSPDBModels;

public partial class Spill : LastUpdate
{
    [Key]
    public int SpillID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "15")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int MunicipalityTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? InfrastructureTVItemID { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime StartDateTime_Local { get; set; }
    [CSSPAfter(Year = 1980)]
    [CSSPBigger(OtherField = "StartDateTime_Local")]
    public DateTime? EndDateTime_Local { get; set; }
    [CSSPRange(0.0D, 1000000.0D)]
    public double AverageFlow_m3_day { get; set; }

    public Spill() : base()
    {
    }
}

