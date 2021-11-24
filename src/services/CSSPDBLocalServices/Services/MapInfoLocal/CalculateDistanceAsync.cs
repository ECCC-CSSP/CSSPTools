namespace CSSPDBLocalServices;

public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
{
    public async Task<double> CalculateDistanceAsync(double lat1, double long1, double lat2, double long2, double EarthRadius)
    {
        return await Task.FromResult(Math.Abs(EarthRadius * Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(long2 - long1))));
    }

}

