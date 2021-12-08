namespace CSSPModels;

[NotMapped]
public partial class LatLng
{
    [CSSPRange(-180.0D, 180.0D)]
    public double Lat { get; set; }
    [CSSPRange(-90.0D, 90.0D)]
    public double Lng { get; set; }

    public LatLng() : base()
    {
    }
}

