namespace CSSPModels;

[NotMapped]
public partial class VPScenarioIDAndRawResults
{
    [CSSPRange(1, -1)]
    public int VPScenarioID { get; set; }
    [CSSPMaxLength(1000000)]
    public string RawResults { get; set; }

    public VPScenarioIDAndRawResults() : base()
    {
    }
}

