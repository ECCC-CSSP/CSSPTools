namespace CSSPDBModels;

public partial class MikeScenario : LastUpdate
{
    [Key]
    public int MikeScenarioID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "13")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int MikeScenarioTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "MikeScenario", ExistPlurial = "s", ExistFieldID = "MikeScenarioID", AllowableTVTypeList = "13")]
    [CSSPForeignKey(TableName = "MikeScenarios", FieldName = "MikeScenarioID")]
    public int? ParentMikeScenarioID { get; set; }
    [CSSPEnumType]
    public ScenarioStatusEnum ScenarioStatus { get; set; }
    [CSSPAllowNull]
    public string ErrorInfo { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime MikeScenarioStartDateTime_Local { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime MikeScenarioEndDateTime_Local { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? MikeScenarioStartExecutionDateTime_Local { get; set; }
    [CSSPRange(1.0D, 100000.0D)]
    public double? MikeScenarioExecutionTime_min { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double WindSpeed_km_h { get; set; }
    [CSSPRange(0.0D, 360.0D)]
    public double WindDirection_deg { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double DecayFactor_per_day { get; set; }
    public bool DecayIsConstant { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double DecayFactorAmplitude { get; set; }
    [CSSPRange(0, 100)]
    public int ResultFrequency_min { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double AmbientTemperature_C { get; set; }
    [CSSPRange(0.0D, 40.0D)]
    public double AmbientSalinity_PSU { get; set; }
    public bool? GenerateDecouplingFiles { get; set; }
    public bool? UseDecouplingFiles { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "31")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? ForSimulatingMWQMRunTVItemID { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double ManningNumber { get; set; }
    [CSSPRange(1, 1000000)]
    public int? NumberOfElements { get; set; }
    [CSSPRange(1, 1000000)]
    public int? NumberOfTimeSteps { get; set; }
    [CSSPRange(0, 100)]
    public int? NumberOfSigmaLayers { get; set; }
    [CSSPRange(0, 100)]
    public int? NumberOfZLayers { get; set; }
    [CSSPRange(0, 100)]
    public int? NumberOfHydroOutputParameters { get; set; }
    [CSSPRange(0, 100)]
    public int? NumberOfTransOutputParameters { get; set; }
    [CSSPRange(0, 100000000)]
    public long? EstimatedHydroFileSize { get; set; }
    [CSSPRange(0, 100000000)]
    public long? EstimatedTransFileSize { get; set; }

    public MikeScenario() : base()
    {
    }
}

