namespace CSSPModels;

[NotMapped]
public partial class Coord
{
    [CSSPRange(-180.0D, 180.0D)]
    public double Lat { get; set; }
    [CSSPRange(-90.0D, 90.0D)]
    public double Lng { get; set; }
    [CSSPRange(0, 10000)]
    public int Ordinal { get; set; }

    public Coord() : base()
    {
    }
}

