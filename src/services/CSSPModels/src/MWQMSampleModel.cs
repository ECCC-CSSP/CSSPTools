namespace CSSPModels;

[NotMapped]
public partial class MWQMSampleModel
{
    public MWQMSample MWQMSample { get; set; }
    public List<MWQMSampleLanguage> MWQMSampleLanguageList { get; set; }

    public MWQMSampleModel()
    {
        MWQMSample = new MWQMSample();
        MWQMSampleLanguageList = new List<MWQMSampleLanguage>();
    }
}

