namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> GetRunSiteSampleStatsUnderProvinceAsync(List<TVItem> TVItemList, List<TVItem> TVItemProvList, List<TVItemStat> TVItemStat2List)
    {
        CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

        foreach (TVItem tvItem in TVItemProvList)
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMonitoringRoutineStatsProvince, tvItem.TVItemID);
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMonitoringOtherStatsProvince, tvItem.TVItemID);

            WebMonitoringRoutineStatsProvince webMonitoringRoutineStatsProvince;
            WebMonitoringOtherStatsProvince webMonitoringOtherStatsProvince;

            using (StreamReader srLocal = new StreamReader($@"{Configuration["azure_csspjson_backup_uncompress"]}WebMonitoringRoutineStatsProvince_{tvItem.TVItemID}.json"))
            {
                webMonitoringRoutineStatsProvince = JsonSerializer.Deserialize<WebMonitoringRoutineStatsProvince>(srLocal.ReadToEnd());
            }

            using (StreamReader srLocal = new StreamReader($@"{Configuration["azure_csspjson_backup_uncompress"]}WebMonitoringOtherStatsProvince_{tvItem.TVItemID}.json"))
            {
                webMonitoringOtherStatsProvince = JsonSerializer.Deserialize<WebMonitoringOtherStatsProvince>(srLocal.ReadToEnd());
            }

            // --------------------------------------
            // doing Province
            // -------------------------------------- 
            Console.WriteLine($"Doing Child Count Province [{tvItem.TVItemID}] ...");

            int ChildMWQMRunCountProv = 0;
            int ChildMWQMSiteCountProv = 0;
            int ChildMWQMSampleCountProv = 0;
            MonitoringStatsModel monitoringStatsModel = webMonitoringRoutineStatsProvince.MonitoringStatsModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID).FirstOrDefault();

            foreach (MonitoringStatByYear monitoringStatByYear in monitoringStatsModel.MonitoringStatByYearList)
            {
                ChildMWQMRunCountProv += monitoringStatByYear.MWQMRunCount;
                ChildMWQMSiteCountProv += monitoringStatByYear.MWQMSiteCount;
                ChildMWQMSampleCountProv += monitoringStatByYear.MWQMSampleCount;
            }

            monitoringStatsModel = webMonitoringOtherStatsProvince.MonitoringStatsModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID).FirstOrDefault();

            foreach (MonitoringStatByYear monitoringStatByYear in monitoringStatsModel.MonitoringStatByYearList)
            {
                ChildMWQMRunCountProv += monitoringStatByYear.MWQMRunCount;
                ChildMWQMSiteCountProv += monitoringStatByYear.MWQMSiteCount;
                ChildMWQMSampleCountProv += monitoringStatByYear.MWQMSampleCount;
            }

            TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMRun, ChildCount = ChildMWQMRunCountProv, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
            TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMSite, ChildCount = ChildMWQMSiteCountProv, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
            TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMSiteSample, ChildCount = ChildMWQMSampleCountProv, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });


            // --------------------------------------
            // doing Area
            // -------------------------------------- 
            foreach (TVItem tvItemArea in (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Area && c.TVPath.StartsWith(tvItem.TVPath + "p"))
                                           select c).ToList())
            {
                int ChildMWQMRunCountArea = 0;
                int ChildMWQMSiteCountArea = 0;
                int ChildMWQMSampleCountArea = 0;
                MonitoringStatsModel monitoringStatsModelArea = webMonitoringRoutineStatsProvince.MonitoringStatsModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItemArea.TVItemID).FirstOrDefault();

                foreach (MonitoringStatByYear monitoringStatByYear in monitoringStatsModelArea.MonitoringStatByYearList)
                {
                    ChildMWQMRunCountArea += monitoringStatByYear.MWQMRunCount;
                    ChildMWQMSiteCountArea += monitoringStatByYear.MWQMSiteCount;
                    ChildMWQMSampleCountArea += monitoringStatByYear.MWQMSampleCount;
                }

                monitoringStatsModelArea = webMonitoringOtherStatsProvince.MonitoringStatsModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItemArea.TVItemID).FirstOrDefault();

                foreach (MonitoringStatByYear monitoringStatByYear in monitoringStatsModel.MonitoringStatByYearList)
                {
                    ChildMWQMRunCountArea += monitoringStatByYear.MWQMRunCount;
                    ChildMWQMSiteCountArea += monitoringStatByYear.MWQMSiteCount;
                    ChildMWQMSampleCountArea += monitoringStatByYear.MWQMSampleCount;
                }

                TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMRun, ChildCount = ChildMWQMRunCountArea, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
                TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMSite, ChildCount = ChildMWQMSiteCountArea, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
                TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMSiteSample, ChildCount = ChildMWQMSampleCountArea, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
            }

            // --------------------------------------
            // doing Sector
            // -------------------------------------- 
            foreach (TVItem tvItemSector in (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Sector && c.TVPath.StartsWith(tvItem.TVPath + "p"))
                                             select c).ToList())
            {
                int ChildMWQMRunCountSector = 0;
                int ChildMWQMSiteCountSector = 0;
                int ChildMWQMSampleCountSector = 0;
                MonitoringStatsModel monitoringStatsModelSector = webMonitoringRoutineStatsProvince.MonitoringStatsModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItemSector.TVItemID).FirstOrDefault();

                foreach (MonitoringStatByYear monitoringStatByYear in monitoringStatsModelSector.MonitoringStatByYearList)
                {
                    ChildMWQMRunCountSector += monitoringStatByYear.MWQMRunCount;
                    ChildMWQMSiteCountSector += monitoringStatByYear.MWQMSiteCount;
                    ChildMWQMSampleCountSector += monitoringStatByYear.MWQMSampleCount;
                }

                monitoringStatsModelSector = webMonitoringOtherStatsProvince.MonitoringStatsModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItemSector.TVItemID).FirstOrDefault();

                foreach (MonitoringStatByYear monitoringStatByYear in monitoringStatsModel.MonitoringStatByYearList)
                {
                    ChildMWQMRunCountSector += monitoringStatByYear.MWQMRunCount;
                    ChildMWQMSiteCountSector += monitoringStatByYear.MWQMSiteCount;
                    ChildMWQMSampleCountSector += monitoringStatByYear.MWQMSampleCount;
                }

                TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMRun, ChildCount = ChildMWQMRunCountSector, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
                TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMSite, ChildCount = ChildMWQMSiteCountSector, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
                TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMSiteSample, ChildCount = ChildMWQMSampleCountSector, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
            }

            // --------------------------------------
            // doing Subsector
            // -------------------------------------- 
            foreach (TVItem tvItemSubsector in (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Subsector && c.TVPath.StartsWith(tvItem.TVPath + "p"))
                                                select c).ToList())
            {
                int ChildMWQMRunCountSubsector = 0;
                int ChildMWQMSiteCountSubsector = 0;
                int ChildMWQMSampleCountSubsector = 0;
                MonitoringStatsModel monitoringStatsModelSubsector = webMonitoringRoutineStatsProvince.MonitoringStatsModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItemSubsector.TVItemID).FirstOrDefault();

                foreach (MonitoringStatByYear monitoringStatByYear in monitoringStatsModelSubsector.MonitoringStatByYearList)
                {
                    ChildMWQMRunCountSubsector += monitoringStatByYear.MWQMRunCount;
                    ChildMWQMSiteCountSubsector += monitoringStatByYear.MWQMSiteCount;
                    ChildMWQMSampleCountSubsector += monitoringStatByYear.MWQMSampleCount;
                }

                monitoringStatsModelSubsector = webMonitoringOtherStatsProvince.MonitoringStatsModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItemSubsector.TVItemID).FirstOrDefault();

                foreach (MonitoringStatByYear monitoringStatByYear in monitoringStatsModel.MonitoringStatByYearList)
                {
                    ChildMWQMRunCountSubsector += monitoringStatByYear.MWQMRunCount;
                    ChildMWQMSiteCountSubsector += monitoringStatByYear.MWQMSiteCount;
                    ChildMWQMSampleCountSubsector += monitoringStatByYear.MWQMSampleCount;
                }

                TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMRun, ChildCount = ChildMWQMRunCountSubsector, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
                TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMSite, ChildCount = ChildMWQMSiteCountSubsector, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
                TVItemStat2List.Add(new TVItemStat() { TVItemID = tvItem.TVItemID, DBCommand = DBCommandEnum.Original, TVType = TVTypeEnum.MWQMSiteSample, ChildCount = ChildMWQMSampleCountSubsector, LastUpdateDate_UTC = DateTime.Now, LastUpdateContactTVItemID = 2 });
            }
        }

        CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

        return await Task.FromResult(Ok(true));
    }
}

