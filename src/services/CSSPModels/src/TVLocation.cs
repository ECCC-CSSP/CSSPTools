namespace CSSPModels;

[NotMapped]
public partial class TVLocation
{
    [CSSPRange(1, -1)]
    public int TVItemID { get; set; }
    [CSSPMaxLength(255)]
    [CSSPMinLength(1)]
    public string TVText { get; set; }
    [CSSPEnumType]
    public TVTypeEnum TVType { get; set; }
    [CSSPEnumType]
    public TVTypeEnum SubTVType { get; set; }
    [CSSPMaxLength(100)]
    [CSSPEnumTypeText(EnumTypeName = "TVTypeEnum", EnumType = "TVType")]
    [CSSPAllowNull]
    public string TVTypeText { get; set; }
    [CSSPMaxLength(100)]
    [CSSPEnumTypeText(EnumTypeName = "TVTypeEnum", EnumType = "SubTVType")]
    [CSSPAllowNull]
    public string SubTVTypeText { get; set; }
    public List<MapObj> MapObjList { get; set; }

    public TVLocation() : base()
    {
        MapObjList = new List<MapObj>();
    }
}

