namespace CSSPDBModels;

public partial class CoCoRaHSSite : LastUpdate
{
    [Key]
    public int CoCoRaHSSiteID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPMaxLength(100)]
    public string StationNumber { get; set; }
    [CSSPMaxLength(100)]
    public string StationName { get; set; }
    [CSSPRange(-90.0D, 90.0D)]
    public double Latitude { get; set; }
    [CSSPRange(-180.0D, 180.0D)]
    public double Longitude { get; set; }

    public CoCoRaHSSite() : base()
    {
    }
}


