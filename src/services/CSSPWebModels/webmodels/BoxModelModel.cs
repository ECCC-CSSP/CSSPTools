namespace CSSPWebModels;

[NotMapped]
public partial class BoxModelModel
{
    public BoxModel BoxModel { get; set; }
    public List<BoxModelLanguage> BoxModelLanguageList { get; set; }
    public List<BoxModelResult> BoxModelResultList { get; set; }

    public BoxModelModel()
    {
        BoxModel = new BoxModel();
        BoxModelLanguageList = new List<BoxModelLanguage>();
        BoxModelResultList = new List<BoxModelResult>();
    }
}

