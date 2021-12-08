namespace CSSPModels;

[NotMapped]
public partial class TVFileModelByPurpose
{
    [CSSPEnumType]
    public FilePurposeEnum FilePurpose { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }

    public TVFileModelByPurpose()
    {
        TVFileModelList = new List<TVFileModel>();
    }
}

