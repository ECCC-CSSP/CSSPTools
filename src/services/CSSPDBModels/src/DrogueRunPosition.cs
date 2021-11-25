namespace CSSPDBModels;

public partial class DrogueRunPosition : LastUpdate
{
    [Key]
    public int DrogueRunPositionID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "DrogueRun", ExistPlurial = "s", ExistFieldID = "DrogueRunID")]
    [CSSPForeignKey(TableName = "DrogueRuns", FieldName = "DrogueRunID")]
    public int DrogueRunID { get; set; }
    [CSSPRange(0, 100000)]
    public int Ordinal { get; set; }
    [CSSPRange(-180.0D, 180.0D)]
    public double StepLat { get; set; }
    [CSSPRange(-90.0D, 90.0D)]
    public double StepLng { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime StepDateTime_Local { get; set; }
    [CSSPRange(0.0D, 10.0D)]
    public double CalculatedSpeed_m_s { get; set; }
    [CSSPRange(0.0D, 360.0D)]
    public double CalculatedDirection_deg { get; set; }

    public DrogueRunPosition() : base()
    {
    }
}

