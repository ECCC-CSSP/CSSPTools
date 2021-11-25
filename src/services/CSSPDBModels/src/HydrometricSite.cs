namespace CSSPDBModels;

public partial class HydrometricSite : LastUpdate
{
    [Key]
    public int HydrometricSiteID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "9")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int HydrometricSiteTVItemID { get; set; }
    [CSSPMaxLength(7)]
    [CSSPAllowNull]
    public string FedSiteNumber { get; set; }
    [CSSPMaxLength(7)]
    [CSSPAllowNull]
    public string QuebecSiteNumber { get; set; }
    [CSSPMaxLength(200)]
    public string HydrometricSiteName { get; set; }
    [CSSPMaxLength(200)]
    [CSSPAllowNull]
    public string Description { get; set; }
    [CSSPMaxLength(4)]
    public string Province { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double? Elevation_m { get; set; }
    [CSSPAfter(Year = 1849)]
    public DateTime? StartDate_Local { get; set; }
    [CSSPAfter(Year = 1849)]
    [CSSPBigger(OtherField = "StartDate_Local")]
    public DateTime? EndDate_Local { get; set; }
    [CSSPRange(-10.0D, 0.0D)]
    public double? TimeOffset_hour { get; set; }
    [CSSPRange(0.0D, 1000000.0D)]
    public double? DrainageArea_km2 { get; set; }
    public bool? IsNatural { get; set; }
    public bool? IsActive { get; set; }
    public bool? Sediment { get; set; }
    public bool? RHBN { get; set; }
    public bool? RealTime { get; set; }
    public bool? HasDischarge { get; set; }
    public bool? HasLevel { get; set; }
    public bool? HasRatingCurve { get; set; }

    public HydrometricSite() : base()
    {
    }
}

