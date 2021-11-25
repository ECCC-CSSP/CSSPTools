namespace CSSPWebModels;

[NotMapped]
public partial class WebLabSheets
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<LabSheetModel> LabSheetModelList { get; set; }

    public WebLabSheets()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        LabSheetModelList = new List<LabSheetModel>();
    }
}

