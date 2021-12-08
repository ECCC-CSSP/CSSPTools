namespace CSSPModels;

[NotMapped]
public partial class SamplingPlanAndFilesLabSheetCount
{
    [CSSPRange(0, -1)]
    public int LabSheetHistoryCount { get; set; }
    [CSSPRange(0, -1)]
    public int LabSheetTransferredCount { get; set; }
    public SamplingPlan SamplingPlan { get; set; }
    public TVFile TVFileSamplingPlanFileTXT { get; set; }

    public SamplingPlanAndFilesLabSheetCount() : base()
    {
    }
}

