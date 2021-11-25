namespace CSSPWebModels;

[NotMapped]
public partial class LabSheetModel
{
    public LabSheet LabSheet { get; set; }
    public LabSheetDetail LabSheetDetail { get; set; }
    public List<LabSheetTubeMPNDetail> LabSheetTubeMPNDetailList { get; set; }

    public LabSheetModel()
    {
        LabSheet = new LabSheet();
        LabSheetDetail = new LabSheetDetail();
        LabSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
    }
}

