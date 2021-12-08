namespace CSSPModels;

[NotMapped]
public partial class OtherFilesToUpload
{
    [CSSPRange(1, -1)]
    public int MikeScenarioID { get; set; }
    public List<TVFile> TVFileList { get; set; }

    public OtherFilesToUpload() : base()
    {
        TVFileList = new List<TVFile>();
    }
}

