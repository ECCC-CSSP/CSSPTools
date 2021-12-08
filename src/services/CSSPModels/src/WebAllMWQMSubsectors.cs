namespace CSSPModels;

[NotMapped]
public partial class WebAllMWQMSubsectors
{
    public List<MWQMSubsectorModel> MWQMSubsectorModelList { get; set; }

    public WebAllMWQMSubsectors()
    {
        MWQMSubsectorModelList = new List<MWQMSubsectorModel>();
    }
}

