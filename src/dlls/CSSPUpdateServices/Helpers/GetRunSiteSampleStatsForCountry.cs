using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        private async Task GetRunSiteSampleStatsForCountry(List<TVItemStat> TVItemStat2List)
        {
            foreach (TVItem tvItem in (from c in db.TVItems
                                       where c.TVType == TVTypeEnum.Country
                                       select c).ToList())
            {
                Console.WriteLine($"Create WebMonitoringRoutineStatsCountry [{tvItem.TVItemID}] doing...");
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsCountry, tvItem.TVItemID);
                Console.WriteLine($"Create WebMonitoringOtherStatsCountry [{tvItem.TVItemID}] doing...");
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsCountry, tvItem.TVItemID);

                WebMonitoringRoutineStatsCountry webMonitoringRoutineStatsCountry;
                WebMonitoringOtherStatsCountry webMonitoringOtherStatsCountry;

                using (StreamReader srLocal = new StreamReader($@"{azure_csspjson_backup_uncompress}WebMonitoringRoutineStatsCountry_{tvItem.TVItemID}.json"))
                {
                    webMonitoringRoutineStatsCountry = JsonSerializer.Deserialize<WebMonitoringRoutineStatsCountry>(srLocal.ReadToEnd());
                }

                using (StreamReader srLocal = new StreamReader($@"{azure_csspjson_backup_uncompress}WebMonitoringOtherStatsCountry_{tvItem.TVItemID}.json"))
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

        }
    }
}
