namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListMunicipalityOfChangedInfrastructureAsync(DateTime LastWriteTimeUtc)
    {
        List<TVItem> tvItemInfrastructureList = (from c in db.TVItems
                                                 where c.TVType == TVTypeEnum.Infrastructure
                                                 select c).ToList();

        List<int> TVItemIDList1 = (from c in db.TVItems
                                   from cl in db.TVItemLanguages
                                   where c.TVItemID == cl.TVItemID
                                   && c.TVType == TVTypeEnum.Infrastructure
                                   && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                   || cl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                   select c.TVItemID).ToList();

        List<int> TVItemIDList2 = (from c in db.Infrastructures
                                   from cl in db.InfrastructureLanguages
                                   where c.InfrastructureID == cl.InfrastructureID
                                   && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                   || cl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                   select c.InfrastructureTVItemID).ToList();

        List<int> infrastructureTVItemIDList = TVItemIDList1.Concat(TVItemIDList2).Distinct().ToList();

        List<int> municipalityTVItemIDList = new List<int>();

        foreach (int infrastructureTVItemID in infrastructureTVItemIDList)
        {
            TVItem tvItemInfrastructure = tvItemInfrastructureList.Where(c => c.TVItemID == infrastructureTVItemID).FirstOrDefault();

            if (tvItemInfrastructure != null)
            {
                if (!municipalityTVItemIDList.Where(c => c == tvItemInfrastructure.ParentID).Any())
                {
                    municipalityTVItemIDList.Add((int)tvItemInfrastructure.ParentID);
                }
            }
        }

        return await Task.FromResult(municipalityTVItemIDList);
    }
}

