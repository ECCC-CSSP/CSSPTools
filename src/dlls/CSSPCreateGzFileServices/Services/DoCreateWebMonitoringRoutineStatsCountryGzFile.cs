/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebMonitoringRoutineStatsCountryGzFile(int CountryTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem tvItemRoot = await GetTVItemRoot();

            TVItem tvItemTest = await GetTVItemWithTVItemID(CountryTVItemID);

            if (tvItemTest == null || tvItemTest.TVType != TVTypeEnum.Country)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_,
                    "TVItem", "TVType", TVTypeEnum.Country.ToString())));
            }

            TVItem tvItemCountry = await GetTVItemWithTVItemID(CountryTVItemID);
            List<TVItemLanguage> tvItemLanguageCountryList = await GetTVItemLanguageWithTVItemID(CountryTVItemID);

            WebMonitoringRoutineStatsCountry webMonitoringRoutineStatsCountry = new WebMonitoringRoutineStatsCountry();

            List<MonitoringStatByYear> monitoringStatByYearRoutineCountryList = new List<MonitoringStatByYear>();

            for (int year = DateTime.Now.Year; year >= 1980; year--)
            {
                Console.WriteLine($"Doing Year {year}...");

                MonitoringStatByYear monitoringStatByYearRoutine = new MonitoringStatByYear();
                monitoringStatByYearRoutine.Year = year;
                monitoringStatByYearRoutine.MWQMSiteCount = GetMWQMSiteCountRoutineByYearUnderCountry(tvItemCountry, year);
                monitoringStatByYearRoutine.MWQMRunCount = GetMWQMRunCountRoutineByYearUnderCountry(tvItemCountry, year);
                monitoringStatByYearRoutine.MWQMSampleCount = GetMWQMSampleCountRoutineByYearUnderCountry(tvItemCountry, year);

                monitoringStatByYearRoutineCountryList.Add(monitoringStatByYearRoutine);
            }

            List<MonitoringStatByMonth> monitoringStatByMonthRoutineCountryList = new List<MonitoringStatByMonth>();

            for (int month = 1; month < 13; month++)
            {
                Console.WriteLine($"Doing Month {(MonthEnum)month}...");

                MonitoringStatByMonth monitoringStatByMonthRoutine = new MonitoringStatByMonth();
                monitoringStatByMonthRoutine.Month = (MonthEnum)month;
                monitoringStatByMonthRoutine.MWQMSiteCount = GetMWQMSiteCountRoutineByMonthUnderCountry(tvItemCountry, (MonthEnum)month);
                monitoringStatByMonthRoutine.MWQMRunCount = GetMWQMRunCountRoutineByMonthUnderCountry(tvItemCountry, (MonthEnum)month);
                monitoringStatByMonthRoutine.MWQMSampleCount = GetMWQMSampleCountRoutineByMonthUnderCountry(tvItemCountry, (MonthEnum)month);

                monitoringStatByMonthRoutineCountryList.Add(monitoringStatByMonthRoutine);
            }

            List<MonitoringStatBySeason> monitoringStatBySeasonRoutineCountryList = new List<MonitoringStatBySeason>();

            for (int season = 1; season < 5; season++)
            {
                Console.WriteLine($"Doing Season {(SeasonEnum)season}...");

                MonitoringStatBySeason monitoringStatBySeasonRoutine = new MonitoringStatBySeason();
                monitoringStatBySeasonRoutine.Season = (SeasonEnum)season;
                monitoringStatBySeasonRoutine.MWQMSiteCount = GetMWQMSiteCountRoutineBySeasonUnderCountry(tvItemCountry, (SeasonEnum)season);
                monitoringStatBySeasonRoutine.MWQMRunCount = GetMWQMRunCountRoutineBySeasonUnderCountry(tvItemCountry, (SeasonEnum)season);
                monitoringStatBySeasonRoutine.MWQMSampleCount = GetMWQMSampleCountRoutineBySeasonUnderCountry(tvItemCountry, (SeasonEnum)season);

                monitoringStatBySeasonRoutineCountryList.Add(monitoringStatBySeasonRoutine);
            }

            webMonitoringRoutineStatsCountry.MonitoringStatsModelList.Add(new MonitoringStatsModel()
            {
                TVItemModel = new TVItemModel()
                {
                    TVItem = tvItemCountry,
                    TVItemLanguageList = (from c in tvItemLanguageCountryList
                                          where c.TVItemID == tvItemCountry.TVItemID
                                          select c).ToList()

                },
                MonitoringStatByYearList = monitoringStatByYearRoutineCountryList,
                MonitoringStatByMonthList = monitoringStatByMonthRoutineCountryList,
                MonitoringStatBySeasonList = monitoringStatBySeasonRoutineCountryList,
            });

            try
            {

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebMonitoringRoutineStatsCountry>(webMonitoringRoutineStatsCountry, $"{ WebTypeEnum.WebMonitoringRoutineStatsCountry }_{tvItemCountry.TVItemID}.gz");
                }
                else
                {
                    await DoStore<WebMonitoringRoutineStatsCountry>(webMonitoringRoutineStatsCountry, $"{ WebTypeEnum.WebMonitoringRoutineStatsCountry }_{tvItemCountry.TVItemID}.gz");
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return await Task.FromResult(BadRequest($"{ ex.Message } { inner }"));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}
