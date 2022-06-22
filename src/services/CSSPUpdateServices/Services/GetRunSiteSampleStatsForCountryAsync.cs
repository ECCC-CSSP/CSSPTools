namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> GetRunSiteSampleStatsForCountryAsync(List<TVItemStat> TVItemStat2List)
    {
        CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

        foreach (TVItem tvItem in (from c in db.TVItems
                                   where c.TVType == TVTypeEnum.Country
                                   select c).ToList())
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMonitoringRoutineStatsCountry, tvItem.TVItemID);

            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMonitoringOtherStatsCountry, tvItem.TVItemID);

            WebMonitoringRoutineStatsCountry webMonitoringRoutineStatsCountry;
            WebMonitoringOtherStatsCountry webMonitoringOtherStatsCountry;

            using (StreamReader srLocal = new StreamReader($@"{Configuration["azure_csspjson_backup_uncompress"]}WebMonitoringRoutineStatsCountry_{tvItem.TVItemID.ToString()}.json"))
            {
                webMonitoringRoutineStatsCountry = JsonSerializer.Deserialize<WebMonitoringRoutineStatsCountry>(srLocal.ReadToEnd());
            }

            using (StreamReader srLocal = new StreamReader($@"{Configuration["azure_csspjson_backup_uncompress"]}WebMonitoringOtherStatsCountry_{tvItem.TVItemID.ToString()}.json"))
            {
                webMonitoringOtherStatsCountry = JsonSerializer.Deserialize<WebMonitoringOtherStatsCountry>(srLocal.ReadToEnd());
            }

            int ChildMWQMRunCount = 0;
            int ChildMWQMSiteCount = 0;
            int ChildMWQMSampleCount = 0;
            MonitoringStatsModel monitoringStatsModel = webMonitoringRoutineStatsCountry.MonitoringStatsModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID).FirstOrDefault();

            foreach (MonitoringStatByYear monitoringStatByYear in monitoringStatsModel.MonitoringStatByYearList)
            {
                ChildMWQMRunCount += monitoringStatByYear.MWQMRunCount;
                ChildMWQMSiteCount += monitoringStatByYear.MWQMSiteCount;
                ChildMWQMSampleCount += monitoringStatByYear.MWQMSampleCount;
            }

            monitoringStatsModel = webMonitoringOtherStatsCountry.MonitoringStatsModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID).FirstOrDefault();

            foreach (MonitoringStatByYear monitoringStatByYear in monitoringStatsModel.MonitoringStatByYearList)
            {
                ChildMWQMRunCount += monitoringStatByYear.MWQMRunCount;
                ChildMWQMSiteCount += monitoringStatByYear.MWQMSiteCount;
                ChildMWQMSampleCount += monitoringStatByYear.MWQMSampleCount;
            }

            TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMRun, ChildCount = ChildMWQMRunCount, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
            TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMSite, ChildCount = ChildMWQMSiteCount, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
            TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMSiteSample, ChildCount = ChildMWQMSampleCount, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });

        }

        CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

        return await Task.FromResult(Ok(true));
    }
}

