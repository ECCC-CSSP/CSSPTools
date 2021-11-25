namespace CSSPWebModels;

[NotMapped]
public partial class WebAllHelpDocs
{
    public List<HelpDoc> HelpDocList { get; set; }

    public WebAllHelpDocs()
    {
        HelpDocList = new List<HelpDoc>();
    }
}

