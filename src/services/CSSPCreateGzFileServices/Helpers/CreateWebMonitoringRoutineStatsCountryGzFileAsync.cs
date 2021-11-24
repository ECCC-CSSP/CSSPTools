namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebMonitoringRoutineStatsCountryGzFileAsync(int CountryTVItemID)
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

        WebMonitoringRoutineStatsCountry webMonitoringRoutineStatsCountry = new WebMonitoringRoutineStatsCountry();

        List<MonitoringStatByYear> monitoringStatByYearRoutineCountryList = new List<MonitoringStatByYear>();

        for (int year = DateTime.Now.Year; year >= 1980; year--)
        {
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { tvItemLanguageTestList[CSSPCultureService.LangID].TVText } { year } { DateTime.Now }");

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
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { tvItemLanguageTestList[CSSPCultureService.LangID].TVText } { month } { DateTime.Now }");

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
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { tvItemLanguageTestList[CSSPCultureService.LangID].TVText } { season } { DateTime.Now }");

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

            if (Local)
            {
                if (!await StoreLocalAsync<WebMonitoringRoutineStatsCountry>(webMonitoringRoutineStatsCountry, $"{ WebTypeEnum.WebMonitoringRoutineStatsCountry }_{tvItemCountry.TVItemID}.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebMonitoringRoutineStatsCountry>(webMonitoringRoutineStatsCountry, $"{ WebTypeEnum.WebMonitoringRoutineStatsCountry }_{tvItemCountry.TVItemID}.gz")) return await Task.FromResult(false);
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

