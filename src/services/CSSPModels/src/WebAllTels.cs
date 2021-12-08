namespace CSSPModels;

[NotMapped]
public partial class WebAllTels
{
    public List<Tel> TelList { get; set; }

    public WebAllTels()
    {
        TelList = new List<Tel>();
    }
}

