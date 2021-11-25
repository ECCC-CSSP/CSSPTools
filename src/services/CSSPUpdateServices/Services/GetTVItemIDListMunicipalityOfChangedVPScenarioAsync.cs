namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListMunicipalityOfChangedVPScenarioAsync(DateTime LastWriteTimeUtc)
    {
        List<TVItem> TVItemInfrastructureList = (from c in db.TVItems
                                                 where c.TVType == TVTypeEnum.Infrastructure
                                                 select c).ToList();

        List<int> TVItemIDList1 = (from c in db.VPScenarios
                                   where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                   select c.InfrastructureTVItemID).Distinct().ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from c in db.VPScenarios
                                              from l in db.VPScenarioLanguages
                                              where l.VPScenarioID == c.VPScenarioID
                                              && l.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              select c.InfrastructureTVItemID).Distinct().ToList()).Distinct().ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from c in db.VPScenarios
                                              from a in db.VPAmbients
                                              where a.VPScenarioID == c.VPScenarioID
                                              && a.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              select c.InfrastructureTVItemID).Distinct().ToList()).Distinct().ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from c in db.VPScenarios
                                              from r in db.VPResults
                                              where r.VPScenarioID == c.VPScenarioID
                                              && r.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              select c.InfrastructureTVItemID).Distinct().ToList()).Distinct().ToList();


        List<int> municipalityTVItemIDList = new List<int>();

        foreach (int infrastructureTVItemID in TVItemIDList1)
        {
            TVItem tvItemInfrastructure = TVItemInfrastructureList.Where(c => c.TVItemID == infrastructureTVItemID).FirstOrDefault();

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

