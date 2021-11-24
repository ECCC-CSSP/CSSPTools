namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebMonitoringOtherStatsCountryGzFileAsync(int CountryTVItemID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(CountryTVItemID: { CountryTVItemID })";

        CSSPLogService.FunctionLog(FunctionName);

        TVItem tvItemRoot = await GetTVItemRootAsync();

        TVItem tvItemTest = await GetTVItemWithTVItemIDAsync(CountryTVItemID);
        List<TVItemLanguage> tvItemLanguageTestList = await GetTVItemLanguageWithTVItemIDAsync(CountryTVItemID);

        if (tvItemTest == null || tvItemTest.TVType != TVTypeEnum.Country)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", CountryTVItemID.ToString(), "TVType", TVTypeEnum.Country.ToString()));
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        TVItem tvItemCountry = await GetTVItemWithTVItemIDAsync(CountryTVItemID);
        List<TVItemLanguage> tvItemLanguageCountryList = await GetTVItemLanguageWithTVItemIDAsync(CountryTVItemID);

        WebMonitoringOtherStatsCountry webMonitoringOtherStatsCountry = new WebMonitoringOtherStatsCountry();

        List<MonitoringStatByYear> monitoringStatByYearOtherCountryList = new List<MonitoringStatByYear>();

        for (int year = DateTime.Now.Year; year >= 1980; year--)
        {
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { tvItemLanguageTestList[CSSPCultureService.LangID].TVText } { year } { DateTime.Now }");

            MonitoringStatByYear monitoringStatByYearOther = new MonitoringStatByYear();
            monitoringStatByYearOther.Year = year;
            monitoringStatByYearOther.MWQMSiteCount = GetMWQMSiteCountOtherByYearUnderCountry(tvItemCountry, year);
            monitoringStatByYearOther.MWQMRunCount = GetMWQMRunCountOtherByYearUnderCountry(tvItemCountry, year);
            monitoringStatByYearOther.MWQMSampleCount = GetMWQMSampleCountOtherByYearUnderCountry(tvItemCountry, year);

            monitoringStatByYearOtherCountryList.Add(monitoringStatByYearOther);
        }

        List<MonitoringStatByMonth> monitoringStatByMonthOtherCountryList = new List<MonitoringStatByMonth>();

        for (int month = 1; month < 13; month++)
        {
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { tvItemLanguageTestList[CSSPCultureService.LangID].TVText } { month } { DateTime.Now }");

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
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { tvItemLanguageTestList[CSSPCultureService.LangID].TVText } { season } { DateTime.Now }");

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

            if (Local)
            {
                if (!await StoreLocalAsync<WebMonitoringOtherStatsCountry>(webMonitoringOtherStatsCountry, $"{ WebTypeEnum.WebMonitoringOtherStatsCountry }_{tvItemCountry.TVItemID}.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebMonitoringOtherStatsCountry>(webMonitoringOtherStatsCountry, $"{ WebTypeEnum.WebMonitoringOtherStatsCountry }_{tvItemCountry.TVItemID}.gz")) return await Task.FromResult(false);
            }
        }
        catch (Exception ex)
        {
            string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
            CSSPLogService.AppendError($"{ ex.Message } { inner }");
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}

