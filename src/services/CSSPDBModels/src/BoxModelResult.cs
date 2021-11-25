namespace CSSPDBModels;

public partial class BoxModelResult : LastUpdate
{
    [Key]
    public int BoxModelResultID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID")]
    [CSSPForeignKey(TableName = "BoxModels", FieldName = "BoxModelID")]
    public int BoxModelID { get; set; }
    [CSSPEnumType]
    public BoxModelResultTypeEnum BoxModelResultType { get; set; }
    [CSSPRange(0.0D, -1.0D)]
    public double Volume_m3 { get; set; }
    [CSSPRange(0.0D, -1.0D)]
    public double Surface_m2 { get; set; }
    [CSSPRange(0.0D, 100000.0D)]
    public double Radius_m { get; set; }
    [CSSPRange(0.0D, 360.0D)]
    public double? LeftSideDiameterLineAngle_deg { get; set; }
    [CSSPRange(-90.0D, 90.0D)]
    public double? CircleCenterLatitude { get; set; }
    [CSSPRange(-180.0D, 180.0D)]
    public double? CircleCenterLongitude { get; set; }
    public bool FixLength { get; set; }
    public bool FixWidth { get; set; }
    [CSSPRange(0.0D, 100000.0D)]
    public double RectLength_m { get; set; }
    [CSSPRange(0.0D, 100000.0D)]
    public double RectWidth_m { get; set; }
    [CSSPRange(0.0D, 360.0D)]
    public double? LeftSideLineAngle_deg { get; set; }
    [CSSPRange(-90.0D, 90.0D)]
    public double? LeftSideLineStartLatitude { get; set; }
    [CSSPRange(-180.0D, 180.0D)]
    public double? LeftSideLineStartLongitude { get; set; }

    public BoxModelResult() : base()
    {
    }
}

