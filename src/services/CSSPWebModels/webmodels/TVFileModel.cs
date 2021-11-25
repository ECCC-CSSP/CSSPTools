namespace CSSPWebModels;

[NotMapped]
public partial class TVFileModel
{
    public TVItemModel TVItemModel { get; set; }
    public TVFile TVFile { get; set; }
    public List<TVFileLanguage> TVFileLanguageList { get; set; }
    public bool IsLocalized { get; set; }
    public bool ErrorLocalizing { get; set; }

    public TVFileModel()
    {
        TVFile = new TVFile();
        TVFileLanguageList = new List<TVFileLanguage>();
    }
}

