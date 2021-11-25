namespace CSSPWebModels;

[NotMapped]
public partial class ToRecreate
{
    [CSSPEnumType]
    public WebTypeEnum WebType { get; set; }
    public int TVItemID { get; set; }

    public ToRecreate()
    {
    }

    public static void AppendToRecreateList(List<ToRecreate> ToRecreateList, WebTypeEnum webType, int TVItemID)
    {
        if (!(from c in ToRecreateList
              where c.WebType == webType
              && c.TVItemID == TVItemID
              select c).Any())
        {
            ToRecreateList.Add(new ToRecreate() { WebType = webType, TVItemID = TVItemID });
        }
    }
}

