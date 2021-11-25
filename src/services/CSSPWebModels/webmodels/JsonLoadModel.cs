namespace CSSPWebModels;

[NotMapped]
public partial class JsonLoadModel
{
    [CSSPEnumType]
    public WebTypeEnum WebType { get; set; }
    public int TVItemID { get; set; }
    public bool ForceReload { get; set; }

    public JsonLoadModel()
    {
    }
}

