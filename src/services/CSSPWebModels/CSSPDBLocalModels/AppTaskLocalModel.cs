namespace CSSPModels;

[NotMapped]
public partial class AppTaskLocalModel
{
    public AppTask AppTask { get; set; }
    public List<AppTaskLanguage> AppTaskLanguageList { get; set; }

    public AppTaskLocalModel()
    {
        AppTaskLanguageList = new List<AppTaskLanguage>();
    }
}

