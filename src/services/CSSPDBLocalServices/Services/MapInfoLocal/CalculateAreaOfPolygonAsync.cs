namespace CSSPDBLocalServices;

public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
{
    public async Task<double> CalculateAreaOfPolygonAsync(List<Coord> CoordList)
    {
        double TotalArea = 0;

        double MinLat = CoordList.Min(e => e.Lat);
        double MinLong = CoordList.Min(e => e.Lng);
        double DistOneLat = await CalculateDistanceAsync(MinLat * d2r, MinLong * d2r, (MinLat + 1) * d2r, MinLong * d2r, R);
        double DistOneLong = await CalculateDistanceAsync(MinLat * d2r, MinLong * d2r, MinLat * d2r, (MinLong + 1) * d2r, R);

        double SumPositive = 0;
        double SumNegative = 0;
        for (int i = 0; i < CoordList.Count; i++)
        {
            if (i == CoordList.Count - 1)
            {
                SumPositive += (CoordList[i].Lng * DistOneLong) * (CoordList[0].Lat * DistOneLat);
                SumNegative += (CoordList[i].Lat * DistOneLat) * (CoordList[0].Lng * DistOneLong);
            }
            else
            {
                SumPositive += (CoordList[i].Lng * DistOneLong) * (CoordList[i + 1].Lat * DistOneLat);
                SumNegative += (CoordList[i].Lat * DistOneLat) * (CoordList[i + 1].Lng * DistOneLong);
            }

            TotalArea = (SumPositive - SumNegative) / 2;

        }

        return await Task.FromResult(TotalArea);
    }
}

