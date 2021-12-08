namespace CSSPModels;

[NotMapped]
public partial class AppTaskModel
{
    public AppTask AppTask { get; set; }
    public List<AppTaskLanguage> AppTaskLanguageList { get; set; }

    public AppTaskModel()
    {
        AppTaskLanguageList = new List<AppTaskLanguage>();
    }
}

