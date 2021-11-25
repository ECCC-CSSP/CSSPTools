namespace CSSPDBModels;

public partial class Infrastructure : LastUpdate
{
    [Key]
    public int InfrastructureID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int InfrastructureTVItemID { get; set; }
    [CSSPRange(0, 100000)]
    public int? PrismID { get; set; }
    [CSSPRange(0, 100000)]
    public int? TPID { get; set; }
    [CSSPRange(0, 100000)]
    public int? LSID { get; set; }
    [CSSPRange(0, 100000)]
    public int? SiteID { get; set; }
    [CSSPRange(0, 100000)]
    public int? Site { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string InfrastructureCategory { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public InfrastructureTypeEnum? InfrastructureType { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public FacilityTypeEnum? FacilityType { get; set; }
    public bool? HasBackupPower { get; set; }
    public bool? IsMechanicallyAerated { get; set; }
    [CSSPRange(0, 10)]
    public int? NumberOfCells { get; set; }
    [CSSPRange(0, 10)]
    public int? NumberOfAeratedCells { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public AerationTypeEnum? AerationType { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public PreliminaryTreatmentTypeEnum? PreliminaryTreatmentType { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public PrimaryTreatmentTypeEnum? PrimaryTreatmentType { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public SecondaryTreatmentTypeEnum? SecondaryTreatmentType { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public TertiaryTreatmentTypeEnum? TertiaryTreatmentType { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public TreatmentTypeEnum? TreatmentType { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public DisinfectionTypeEnum? DisinfectionType { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public CollectionSystemTypeEnum? CollectionSystemType { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public AlarmSystemTypeEnum? AlarmSystemType { get; set; }
    [CSSPRange(0.0D, 1000000.0D)]
    public double? DesignFlow_m3_day { get; set; }
    [CSSPRange(0.0D, 1000000.0D)]
    public double? AverageFlow_m3_day { get; set; }
    [CSSPRange(0.0D, 1000000.0D)]
    public double? PeakFlow_m3_day { get; set; }
    [CSSPRange(0, 1000000)]
    public int? PopServed { get; set; }
    public bool? CanOverflow { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public ValveTypeEnum? ValveType { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? PercFlowOfTotal { get; set; }
    [CSSPRange(-10.0D, 0.0D)]
    public double? TimeOffset_hour { get; set; }
    [CSSPAllowNull]
    public string TempCatchAllRemoveLater { get; set; }
    [CSSPRange(0.0D, 1000.0D)]
    public double? AverageDepth_m { get; set; }
    [CSSPRange(1, 1000)]
    public int? NumberOfPorts { get; set; }
    [CSSPRange(0.0D, 10.0D)]
    public double? PortDiameter_m { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double? PortSpacing_m { get; set; }
    [CSSPRange(0.0D, 1000.0D)]
    public double? PortElevation_m { get; set; }
    [CSSPRange(-90.0D, 90.0D)]
    public double? VerticalAngle_deg { get; set; }
    [CSSPRange(-180.0D, 180.0D)]
    public double? HorizontalAngle_deg { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? DecayRate_per_day { get; set; }
    [CSSPRange(0.0D, 10.0D)]
    public double? NearFieldVelocity_m_s { get; set; }
    [CSSPRange(0.0D, 10.0D)]
    public double? FarFieldVelocity_m_s { get; set; }
    [CSSPRange(0.0D, 40.0D)]
    public double? ReceivingWaterSalinity_PSU { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? ReceivingWaterTemperature_C { get; set; }
    [CSSPRange(0, 10000000)]
    public int? ReceivingWater_MPN_per_100ml { get; set; }
    [CSSPRange(0.0D, 1000.0D)]
    public double? DistanceFromShore_m { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? SeeOtherMunicipalityTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "2")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? CivicAddressTVItemID { get; set; }

    public Infrastructure() : base()
    {
    }
}

