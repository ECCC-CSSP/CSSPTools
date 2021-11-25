namespace CSSPWebModels;

[NotMapped]
public partial class MWQMSubsectorModel
{
    public MWQMSubsector MWQMSubsector { get; set; }
    public List<MWQMSubsectorLanguage> MWQMSubsectorLanguageList { get; set; }

    public MWQMSubsectorModel()
    {
        MWQMSubsector = new MWQMSubsector();
        MWQMSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
    }
}

