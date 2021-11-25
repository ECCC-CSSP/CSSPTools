namespace CSSPWebModels;

[NotMapped]
public partial class MikeSourceModel
{
    public TVItemModel TVItemModel { get; set; }
    public MikeSource MikeSource { get; set; }
    public List<MikeSourceStartEnd> MikeSourceStartEndList { get; set; }

    public MikeSourceModel()
    {
        TVItemModel = new TVItemModel();
        MikeSource = new MikeSource();
        MikeSourceStartEndList = new List<MikeSourceStartEnd>();
    }
}

