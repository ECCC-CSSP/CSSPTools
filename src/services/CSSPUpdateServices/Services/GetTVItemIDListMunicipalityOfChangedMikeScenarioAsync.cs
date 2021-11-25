namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListMunicipalityOfChangedMikeScenarioAsync(DateTime LastWriteTimeUtc)
    {
        List<TVItem> tvItemMikeScenarioList = (from c in db.TVItems
                                               where c.TVType == TVTypeEnum.MikeScenario
                                               select c).ToList();

        List<int> TVItemIDList1 = (from c in db.TVItems
                                   from cl in db.TVItemLanguages
                                   where c.TVItemID == cl.TVItemID
                                   && c.TVType == TVTypeEnum.MikeScenario
                                   && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                   || cl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                   select c.TVItemID).ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from c in db.TVItems
                                              from cl in db.TVItemLanguages
                                              where c.TVItemID == cl.TVItemID
                                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                                              && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              || cl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                              select (int)c.ParentID).ToList()).Distinct().ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from c in db.TVItems
                                              from cl in db.TVItemLanguages
                                              where c.TVItemID == cl.TVItemID
                                              && c.TVType == TVTypeEnum.MikeSource
                                              && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              || cl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                              select (int)c.ParentID).ToList()).Distinct().ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from c in db.MikeScenarios
                                              where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              select c.MikeScenarioTVItemID).ToList()).Distinct().ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from c in db.MikeScenarioResults
                                              where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              select c.MikeScenarioTVItemID).ToList()).Distinct().ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from t in db.TVItems
                                              from c in db.MikeBoundaryConditions
                                              where t.TVItemID == c.MikeBoundaryConditionTVItemID
                                              && (t.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                                              || t.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                                              && c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              select (int)t.ParentID).ToList()).Distinct().ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from t in db.TVItems
                                              from c in db.MikeSources
                                              from msse in db.MikeSourceStartEnds
                                              where t.TVItemID == c.MikeSourceTVItemID
                                              && c.MikeSourceID == msse.MikeSourceID
                                              && t.TVType == TVTypeEnum.MikeSource
                                              && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              || msse.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                              select (int)t.ParentID).ToList()).Distinct().ToList();

        List<int> MikeScenarioTVItemIDList = TVItemIDList1.Distinct().ToList();

        List<int> TVItemIDList = new List<int>();

        foreach (int mikeScenarioTVItemID in MikeScenarioTVItemIDList)
        {
            TVItem tvItemMikeScenario = tvItemMikeScenarioList.Where(c => c.TVItemID == mikeScenarioTVItemID).FirstOrDefault();

            if (tvItemMikeScenario != null)
            {
                if (!TVItemIDList.Where(c => c == tvItemMikeScenario.ParentID).Any())
                {
                    TVItemIDList.Add((int)tvItemMikeScenario.ParentID);
                }
            }
        }

        return await Task.FromResult(TVItemIDList);
    }
}

