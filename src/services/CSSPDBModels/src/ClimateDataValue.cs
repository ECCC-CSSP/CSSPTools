namespace CSSPDBModels;

public partial class ClimateDataValue : LastUpdate
{
    [Key]
    public int ClimateDataValueID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "ClimateSite", ExistPlurial = "s", ExistFieldID = "ClimateSiteID")]
    [CSSPForeignKey(TableName = "ClimateSites", FieldName = "ClimateSiteID")]
    public int ClimateSiteID { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime DateTime_Local { get; set; }
    public bool Keep { get; set; }
    [CSSPEnumType]
    public StorageDataTypeEnum StorageDataType { get; set; }
    public bool HasBeenRead { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double? Snow_cm { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double? Rainfall_mm { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double? RainfallEntered_mm { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double? TotalPrecip_mm_cm { get; set; }
    [CSSPRange(-50.0D, 50.0D)]
    public double? MaxTemp_C { get; set; }
    [CSSPRange(-50.0D, 50.0D)]
    public double? MinTemp_C { get; set; }
    [CSSPRange(-1000.0D, 100.0D)]
    public double? HeatDegDays_C { get; set; }
    [CSSPRange(-1000.0D, 100.0D)]
    public double? CoolDegDays_C { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double? SnowOnGround_cm { get; set; }
    [CSSPRange(0.0D, 360.0D)]
    public double? DirMaxGust_0North { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? SpdMaxGust_kmh { get; set; }
    [CSSPAllowNull]
    public string HourlyValues { get; set; }

    public ClimateDataValue() : base()
    {
    }
}

