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
        private async Task<ActionResult<bool>> DoCreateWebMonitoringOtherStatsCountryGzFile(int CountryTVItemID)
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

            WebMonitoringOtherStatsCountry webMonitoringOtherStatsCountry = new WebMonitoringOtherStatsCountry();

            List<MonitoringStatByYear> monitoringStatByYearOtherCountryList = new List<MonitoringStatByYear>();

            for (int year = DateTime.Now.Year; year >= 1980; year--)
            {
                Console.WriteLine($"Doing Year {year}...");

                MonitoringStatByYear monitoringStatByYearOther = new MonitoringStatByYear();
                monitoringStatByYearOther.Year = year;
                monitoringStatByYearOther.MWQMSiteCount = GetMWQMSiteCountOtherByYearUnderCountry(tvItemCountry, year);
                monitoringStatByYearOther.MWQMRunCount = GetMWQMRunCountOtherByYearUnderCountry(tvItemCountry, year);
                monitoringStatByYearOther.MWQMSampleCount = GetMWQMSampleCountOtherByYearUnderCountry(tvItemCountry, year);

                monitoringStatByYearOtherCountryList.Add(monitoringStatByYearOther);
            }

            List<MonitoringStatByMonth> monitoringStatByMonthOtherCountryList = new List<MonitoringStatByMonth>();

            for (int month = 1; month < 13 ; month++)
            {
                Console.WriteLine($"Doing month {(MonthEnum)month}...");

                MonitoringStatByMonth monitoringStatByMonthOther = new MonitoringStatByMonth();
                monitoringStatByMonthOther.Month = (MonthEnum)month;
                monitoringStatByMonthOther.MWQMSiteCount = GetMWQMSiteCountOtherByMonthUnderCountry(tvItemCountry, (MonthEnum)month);
                monitoringStatByMonthOther.MWQMRunCount = GetMWQMRunCountOtherByMonthUnderCountry(tvItemCountry, (MonthEnum)month);
                monitoringStatByMonthOther.MWQMSampleCount = GetMWQMSampleCountOtherByMonthUnderCountry(tvItemCountry, (MonthEnum)month);

                monitoringStatByMonthOtherCountryList.Add(monitoringStatByMonthOther);
            }

            List<MonitoringStatBySeason> monitoringStatBySeasonOtherCountryList = new List<MonitoringStatBySeason>();

            for (int season = 1; season < 5; season++)
            {
                Console.WriteLine($"Doing Season {(SeasonEnum)season}...");

                MonitoringStatBySeason monitoringStatBySeasonOther = new MonitoringStatBySeason();
                monitoringStatBySeasonOther.Season = (SeasonEnum)season;
                monitoringStatBySeasonOther.MWQMSiteCount = GetMWQMSiteCountOtherBySeasonUnderCountry(tvItemCountry, (SeasonEnum)season);
                monitoringStatBySeasonOther.MWQMRunCount = GetMWQMRunCountOtherBySeasonUnderCountry(tvItemCountry, (SeasonEnum)season);
                monitoringStatBySeasonOther.MWQMSampleCount = GetMWQMSampleCountOtherBySeasonUnderCountry(tvItemCountry, (SeasonEnum)season);

                monitoringStatBySeasonOtherCountryList.Add(monitoringStatBySeasonOther);
            }

            webMonitoringOtherStatsCountry.MonitoringStatsModelList.Add(new MonitoringStatsModel()
            {
                TVItemModel = new TVItemModel()
                {
                    TVItem = tvItemCountry,
                    TVItemLanguageList = (from c in tvItemLanguageCountryList
                                          where c.TVItemID == tvItemCountry.TVItemID
                                          select c).ToList()

                },
                MonitoringStatByYearList = monitoringStatByYearOtherCountryList,
                MonitoringStatByMonthList = monitoringStatByMonthOtherCountryList,
                MonitoringStatBySeasonList = monitoringStatBySeasonOtherCountryList,
            });

            try
            {

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebMonitoringOtherStatsCountry>(webMonitoringOtherStatsCountry, $"{ WebTypeEnum.WebMonitoringOtherStatsCountry }_{tvItemCountry.TVItemID}.gz");
                }
                else
                {
                    await DoStore<WebMonitoringOtherStatsCountry>(webMonitoringOtherStatsCountry, $"{ WebTypeEnum.WebMonitoringOtherStatsCountry }_{tvItemCountry.TVItemID}.gz");
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
