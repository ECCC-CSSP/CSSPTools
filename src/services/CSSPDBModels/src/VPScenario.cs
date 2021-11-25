namespace CSSPDBModels;

public partial class VPScenario : LastUpdate
{
    [Key]
    public int VPScenarioID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int InfrastructureTVItemID { get; set; }
    [CSSPEnumType]
    public ScenarioStatusEnum VPScenarioStatus { get; set; }
    public bool UseAsBestEstimate { get; set; }
    [CSSPRange(0.0D, 1000.0D)]
    public double? EffluentFlow_m3_s { get; set; }
    [CSSPRange(0, 10000000)]
    public int? EffluentConcentration_MPN_100ml { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double? FroudeNumber { get; set; }
    [CSSPRange(0.0D, 10.0D)]
    public double? PortDiameter_m { get; set; }
    [CSSPRange(0.0D, 1000.0D)]
    public double? PortDepth_m { get; set; }
    [CSSPRange(0.0D, 1000.0D)]
    public double? PortElevation_m { get; set; }
    [CSSPRange(-90.0D, 90.0D)]
    public double? VerticalAngle_deg { get; set; }
    [CSSPRange(-180.0D, 180.0D)]
    public double? HorizontalAngle_deg { get; set; }
    [CSSPRange(1, 100)]
    public int? NumberOfPorts { get; set; }
    [CSSPRange(0.0D, 1000.0D)]
    public double? PortSpacing_m { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? AcuteMixZone_m { get; set; }
    [CSSPRange(0.0D, 40000.0D)]
    public double? ChronicMixZone_m { get; set; }
    [CSSPRange(0.0D, 40.0D)]
    public double? EffluentSalinity_PSU { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? EffluentTemperature_C { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? EffluentVelocity_m_s { get; set; }
    [CSSPAllowNull]
    public string RawResults { get; set; }

    public VPScenario() : base()
    {
    }
}

