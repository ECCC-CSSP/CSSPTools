namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    public async Task<ActionResult<bool>> CreateAllGzFilesAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        await CreateGzFileAsync(WebTypeEnum.WebAllAddresses, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllContacts, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllCountries, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllEmails, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllHelpDocs, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllMunicipalities, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllMWQMAnalysisReportParameters, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllMWQMSubsectors, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllPolSourceGroupings, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllPolSourceSiteEffectTerms, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllProvinces, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllReportTypes, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllTels, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllTideLocations, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllSearch, 0);
        await CreateGzFileAsync(WebTypeEnum.WebAllUseOfSites, 0);

        await CreateGzFileAsync(WebTypeEnum.WebRoot, 0);

        foreach (TVItem tvItem in (from c in db.TVItems
                                   where c.TVType == TVTypeEnum.Country
                                   select c).ToList())
        {
            await CreateGzFileAsync(WebTypeEnum.WebMonitoringRoutineStatsCountry, tvItem.TVItemID);
            await CreateGzFileAsync(WebTypeEnum.WebMonitoringOtherStatsCountry, tvItem.TVItemID);
        }

        foreach (TVItem tvItem in (from c in db.TVItems
                                   where c.TVType == TVTypeEnum.Province
                                   select c).ToList())
        {
            await CreateGzFileAsync(WebTypeEnum.WebMonitoringRoutineStatsProvince, tvItem.TVItemID);
            await CreateGzFileAsync(WebTypeEnum.WebMonitoringOtherStatsProvince, tvItem.TVItemID);
        }

        List<TVTypeEnum> tvTypeEnumList = new List<TVTypeEnum>()
            {
                TVTypeEnum.Country,
                TVTypeEnum.Province,
                TVTypeEnum.Area,
                TVTypeEnum.Sector,
                TVTypeEnum.Subsector,
                TVTypeEnum.Municipality,
            };


        foreach (TVTypeEnum tvType in tvTypeEnumList)
        {

            List<TVItem> tvItemList = (from c in db.TVItems
                                       where c.TVType == tvType
                                       select c).ToList();

            int total = tvItemList.Count;
            int count = 0;
            foreach (TVItem tvItem in tvItemList)
            {
                count += 1;
                Console.WriteLine($"{ count } / { total }");
                switch (tvType)
                {
                    case TVTypeEnum.Area:
                        {
                            await CreateGzFileAsync(WebTypeEnum.WebArea, tvItem.TVItemID);
                        }
                        break;
                    case TVTypeEnum.Country:
                        {
                            await CreateGzFileAsync(WebTypeEnum.WebCountry, tvItem.TVItemID);
                        }
                        break;
                    case TVTypeEnum.Municipality:
                        {
                            await CreateGzFileAsync(WebTypeEnum.WebMunicipality, tvItem.TVItemID);
                            await CreateGzFileAsync(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);
                        }
                        break;
                    case TVTypeEnum.Province:
                        {
                            await CreateGzFileAsync(WebTypeEnum.WebProvince, tvItem.TVItemID);
                            await CreateGzFileAsync(WebTypeEnum.WebClimateSites, tvItem.TVItemID);
                            await CreateGzFileAsync(WebTypeEnum.WebHydrometricSites, tvItem.TVItemID);
                            await CreateGzFileAsync(WebTypeEnum.WebTideSites, tvItem.TVItemID);
                            await CreateGzFileAsync(WebTypeEnum.WebDrogueRuns, tvItem.TVItemID);
                        }
                        break;
                    case TVTypeEnum.Sector:
                        {
                            await CreateGzFileAsync(WebTypeEnum.WebSector, tvItem.TVItemID);
                        }
                        break;
                    case TVTypeEnum.Subsector:
                        {
                            await CreateGzFileAsync(WebTypeEnum.WebSubsector, tvItem.TVItemID);
                            await CreateGzFileAsync(WebTypeEnum.WebMWQMRuns, tvItem.TVItemID);
                            await CreateGzFileAsync(WebTypeEnum.WebMWQMSites, tvItem.TVItemID);
                            await CreateGzFileAsync(WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);
                            await CreateGzFileAsync(WebTypeEnum.WebLabSheets, tvItem.TVItemID);
                            await CreateGzFileAsync(WebTypeEnum.WebMWQMSamples1980_2020, tvItem.TVItemID);
                            await CreateGzFileAsync(WebTypeEnum.WebMWQMSamples2021_2060, tvItem.TVItemID);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0)
        {
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

        CSSPLogService.EndFunctionLog(FunctionName);
        return await Task.FromResult(Ok(true));
    }
}

