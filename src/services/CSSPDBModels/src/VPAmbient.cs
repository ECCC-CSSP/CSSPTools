namespace CSSPDBModels;

public partial class VPAmbient : LastUpdate
{
    [Key]
    public int VPAmbientID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID")]
    [CSSPForeignKey(TableName = "VPScenarios", FieldName = "VPScenarioID")]
    public int VPScenarioID { get; set; }
    [CSSPRange(0, 10)]
    public int Row { get; set; }
    [CSSPRange(0.0D, 1000.0D)]
    public double? MeasurementDepth_m { get; set; }
    [CSSPRange(0.0D, 10.0D)]
    public double? CurrentSpeed_m_s { get; set; }
    [CSSPRange(-180.0D, 180.0D)]
    public double? CurrentDirection_deg { get; set; }
    [CSSPRange(0.0D, 40.0D)]
    public double? AmbientSalinity_PSU { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? AmbientTemperature_C { get; set; }
    [CSSPRange(0, 10000000)]
    public int? BackgroundConcentration_MPN_100ml { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? PollutantDecayRate_per_day { get; set; }
    [CSSPRange(0.0D, 10.0D)]
    public double? FarFieldCurrentSpeed_m_s { get; set; }
    [CSSPRange(-180.0D, 180.0D)]
    public double? FarFieldCurrentDirection_deg { get; set; }
    [CSSPRange(0.0D, 1.0D)]
    public double? FarFieldDiffusionCoefficient { get; set; }

    public VPAmbient() : base()
    {
    }
}

