namespace CSSPDBModels;

public partial class HydrometricDataValue : LastUpdate
{
    [Key]
    public int HydrometricDataValueID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID")]
    [CSSPForeignKey(TableName = "HydrometricSites", FieldName = "HydrometricSiteID")]
    public int HydrometricSiteID { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime DateTime_Local { get; set; }
    public bool Keep { get; set; }
    [CSSPEnumType]
    public StorageDataTypeEnum StorageDataType { get; set; }
    public bool HasBeenRead { get; set; }
    [CSSPRange(0.0D, 100000.0D)]
    public double? Discharge_m3_s { get; set; }
    [CSSPRange(0.0D, 100000.0D)]
    public double? DischargeEntered_m3_s { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double? Level_m { get; set; }
    [CSSPAllowNull]
    public string HourlyValues { get; set; }

    public HydrometricDataValue() : base()
    {
    }
}

