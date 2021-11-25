namespace CSSPDBModels;

public partial class RatingCurveValue : LastUpdate
{
    [Key]
    public int RatingCurveValueID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "RatingCurve", ExistPlurial = "s", ExistFieldID = "RatingCurveID")]
    [CSSPForeignKey(TableName = "RatingCurves", FieldName = "RatingCurveID")]
    public int RatingCurveID { get; set; }
    [CSSPRange(0.0D, 1000.0D)]
    public double StageValue_m { get; set; }
    [CSSPRange(0.0D, 1000000.0D)]
    public double DischargeValue_m3_s { get; set; }

    public RatingCurveValue() : base()
    {
    }
}

