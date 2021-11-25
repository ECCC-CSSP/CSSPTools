namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListMunicipalityOfChangedBoxModelAsync(DateTime LastWriteTimeUtc)
    {
        List<TVItem> tvItemInfrastructureList = (from c in db.TVItems
                                                 where c.TVType == TVTypeEnum.Infrastructure
                                                 select c).ToList();

        List<int> boxModelTVItemIDList = (from c in db.BoxModels
                                          where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                          select c.InfrastructureTVItemID).Distinct().ToList();

        List<int> boxModelResultTVItemIDList = (from c in db.BoxModels
                                                from r in db.BoxModelResults
                                                where r.BoxModelID == c.BoxModelID
                                                && r.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                select c.InfrastructureTVItemID).Distinct().ToList();

        List<int> boxModelLanguageTVItemIDList = (from c in db.BoxModels
                                                  from l in db.BoxModelLanguages
                                                  where l.BoxModelID == c.BoxModelID
                                                  && l.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                  select c.InfrastructureTVItemID).Distinct().ToList();

        List<int> infrastructureTVItemIDList = boxModelTVItemIDList.Concat(boxModelResultTVItemIDList).Concat(boxModelLanguageTVItemIDList).Distinct().ToList();

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

