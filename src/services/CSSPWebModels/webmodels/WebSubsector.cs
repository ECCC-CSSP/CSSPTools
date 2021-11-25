namespace CSSPWebModels;

[NotMapped]
public partial class WebSubsector
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }
    public List<ClassificationModel> ClassificationModelList { get; set; }

    public WebSubsector()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        TVFileModelList = new List<TVFileModel>();
        ClassificationModelList = new List<ClassificationModel>();
    }
}

