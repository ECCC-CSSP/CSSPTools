namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListCountryOfChangedRainExceedanceAsync(DateTime LastWriteTimeUtc)
    {
        List<int> countryTVItemIDList = new List<int>();

        List<TVItem> countryTVItemList = (from c in db.TVItems
                                          where c.TVType == TVTypeEnum.Country
                                          select c).ToList();

        List<TVItem> rainExceedanceTVItemIDList1 = (from t in db.TVItems
                                                    from tl in db.TVItemLanguages
                                                    where t.TVItemID == tl.TVItemID
                                                    && t.TVType == TVTypeEnum.RainExceedance
                                                    && (t.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                    || tl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                                    select t).Distinct().ToList();

        List<TVItem> rainExceedanceTVItemIDList2 = (from t in db.TVItems
                                                    from r in db.RainExceedances
                                                    from rc in db.RainExceedanceClimateSites
                                                    where t.TVItemID == r.RainExceedanceTVItemID
                                                    && r.RainExceedanceTVItemID == rc.RainExceedanceTVItemID
                                                    && (r.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                    || rc.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                                    select t).Distinct().ToList();

        foreach (TVItem tvItemcountry in countryTVItemList)
        {
            bool exist = (from c in rainExceedanceTVItemIDList1
                          where c.TVPath.StartsWith(tvItemcountry.TVPath)
                          select c).Any();

            if (exist)
            {
                countryTVItemIDList.Add(tvItemcountry.TVItemID);
            }


            bool exist2 = (from c in rainExceedanceTVItemIDList2
                           where c.TVPath.StartsWith(tvItemcountry.TVPath)
                           select c).Any();

            if (exist2)
            {
                countryTVItemIDList.Add(tvItemcountry.TVItemID);
            }
        }

        return await Task.FromResult(countryTVItemIDList.Distinct().ToList());
    }
}

