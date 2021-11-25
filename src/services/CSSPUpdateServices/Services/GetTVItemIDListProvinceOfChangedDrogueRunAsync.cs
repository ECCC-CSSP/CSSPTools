namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListProvinceOfChangedDrogueRunAsync(DateTime LastWriteTimeUtc)
    {
        List<int> provinceTVItemIDList = new List<int>();

        List<TVItem> provinceTVItemList = (from c in db.TVItems
                                           where c.TVType == TVTypeEnum.Province
                                           select c).ToList();

        List<TVItem> subsectorTVItemIDList = (from t in db.TVItems
                                              from c in db.DrogueRuns
                                              where t.TVItemID == c.SubsectorTVItemID
                                              && c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              select t).Distinct().ToList();

        List<TVItem> subsectorTVItemIDList2 = (from t in db.TVItems
                                               from c in db.DrogueRuns
                                               from cd in db.DrogueRunPositions
                                               where t.TVItemID == c.SubsectorTVItemID
                                               && c.DrogueRunID == cd.DrogueRunID
                                               && cd.LastUpdateDate_UTC >= LastWriteTimeUtc
                                               select t).Distinct().ToList();

        foreach (TVItem tvItemProvince in provinceTVItemList)
        {
            bool exist = (from c in subsectorTVItemIDList
                          where c.TVPath.StartsWith(tvItemProvince.TVPath)
                          select c).Any();

            if (exist)
            {
                provinceTVItemIDList.Add(tvItemProvince.TVItemID);
            }
            else
            {
                bool exist2 = (from c in subsectorTVItemIDList2
                               where c.TVPath.StartsWith(tvItemProvince.TVPath)
                               select c).Any();

                if (exist2)
                {
                    provinceTVItemIDList.Add(tvItemProvince.TVItemID);
                }
            }
        }


        return await Task.FromResult(provinceTVItemIDList.Distinct().ToList());
    }
}

