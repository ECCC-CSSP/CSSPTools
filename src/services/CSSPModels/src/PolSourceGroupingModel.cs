namespace CSSPModels;

[NotMapped]
public partial class PolSourceGroupingModel
{
    public PolSourceGrouping PolSourceGrouping { get; set; }
    public List<PolSourceGroupingLanguage> PolSourceGroupingLanguageList { get; set; }

    public PolSourceGroupingModel()
    {
        PolSourceGrouping = new PolSourceGrouping();
        PolSourceGroupingLanguageList = new List<PolSourceGroupingLanguage>();
    }
}

