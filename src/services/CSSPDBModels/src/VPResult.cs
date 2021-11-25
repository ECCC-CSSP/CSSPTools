namespace CSSPDBModels;

public partial class VPResult : LastUpdate
{
    [Key]
    public int VPResultID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID")]
    [CSSPForeignKey(TableName = "VPScenarios", FieldName = "VPScenarioID")]
    public int VPScenarioID { get; set; }
    [CSSPRange(0, 1000)]
    public int Ordinal { get; set; }
    [CSSPRange(0, 10000000)]
    public int Concentration_MPN_100ml { get; set; }
    [CSSPRange(0.0D, 1000000.0D)]
    public double Dilution { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double FarFieldWidth_m { get; set; }
    [CSSPRange(0.0D, 100000.0D)]
    public double DispersionDistance_m { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double TravelTime_hour { get; set; }

    public VPResult() : base()
    {
    }
}

