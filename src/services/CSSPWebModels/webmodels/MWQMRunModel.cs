namespace CSSPWebModels;

[NotMapped]
public partial class MWQMRunModel
{
    public TVItemModel TVItemModel { get; set; }
    public MWQMRun MWQMRun { get; set; }
    public List<MWQMRunLanguage> MWQMRunLanguageList { get; set; }

    public MWQMRunModel()
    {
        TVItemModel = new TVItemModel();
        MWQMRun = new MWQMRun();
        MWQMRunLanguageList = new List<MWQMRunLanguage>();
    }
}

