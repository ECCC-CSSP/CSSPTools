namespace CSSPModels;

[NotMapped]
public partial class MapObj
{
    [CSSPRange(1, -1)]
    public int MapInfoID { get; set; }
    [CSSPEnumType]
    public MapInfoDrawTypeEnum MapInfoDrawType { get; set; }
    [CSSPMaxLength(100)]
    [CSSPEnumTypeText(EnumTypeName = "MapInfoDrawTypeEnum", EnumType = "MapInfoDrawType")]
    [CSSPAllowNull]
    public string MapInfoDrawTypeText { get; set; }
    public List<Coord> CoordList { get; set; }

    public MapObj() : base()
    {
        CoordList = new List<Coord>();
    }
}

