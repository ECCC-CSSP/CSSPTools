namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebMonitoringRoutineStatsProvinceGzFileAsync(int ProvinceTVItemID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(ProvinceTVItemID: { ProvinceTVItemID })";
        CSSPLogService.FunctionLog(FunctionName);

        TVItem tvItemRoot = await GetTVItemRootAsync();

        TVItem tvItemTest = await GetTVItemWithTVItemIDAsync(ProvinceTVItemID);
        List<TVItemLanguage> tvItemLanguageProvinceTestList = await GetTVItemLanguageWithTVItemIDAsync(ProvinceTVItemID);

        if (tvItemTest == null || tvItemTest.TVType != TVTypeEnum.Province)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()));
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        TVItem tvItemProv = await GetTVItemWithTVItemIDAsync(ProvinceTVItemID);
        List<TVItemLanguage> tvItemLanguageProvList = await GetTVItemLanguageWithTVItemIDAsync(ProvinceTVItemID);

        WebMonitoringRoutineStatsProvince webMonitoringRoutineStatsProvince = new WebMonitoringRoutineStatsProvince();

        List<TVItem> tvItemSubsectorList = await GetTVItemAllChildrenListWithTVItemIDAsync(tvItemProv, TVTypeEnum.Subsector);
        List<TVItemLanguage> tvItemLanguageSubsectorList = await GetTVItemLanguageAllChildrenListWithTVItemIDAsync(tvItemProv, TVTypeEnum.Subsector);

        // doing Subsector -------------------------------------------
        // -----------------------------------------------------------
        foreach (TVItem tvItemSubsector in tvItemSubsectorList)
        {
            List<TVItemLanguage> TVItemLanguageSSList = (from c in tvItemLanguageSubsectorList
                                                         where c.TVItemID == tvItemSubsector.TVItemID
                                                         select c).ToList();

            string TVTextSS = TVItemLanguageSSList[CSSPCultureService.LangID].TVText;
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { TVTextSS } { DateTime.Now }");

            string subsector = TVTextSS;

            if (subsector.Contains(" "))
            {
                subsector = TVTextSS.Substring(0, TVTextSS.IndexOf(" "));
            }

            List<MWQMSample> mwqmSampleList = await GetMWQMSampleListUnderSubsectorAsync(tvItemSubsector);

            List<MonitoringStatByYear> monitoringStatByYearRoutineSubsectorList = new List<MonitoringStatByYear>();

            for (int year = DateTime.Now.Year; year >= 1980; year--)
            {
                MonitoringStatByYear monitoringStatByYearRoutine = new MonitoringStatByYear();
                monitoringStatByYearRoutine.Year = year;
                monitoringStatByYearRoutine.MWQMSiteCount = (from c in mwqmSampleList
                                                             where c.SampleDateTime_Local.Year == year
                                                             && c.SampleTypesText.Contains("109")
                                                             select c.MWQMSiteTVItemID).Distinct().Count();
                monitoringStatByYearRoutine.MWQMRunCount = (from c in mwqmSampleList
                                                            where c.SampleDateTime_Local.Year == year
                                                            && c.SampleTypesText.Contains("109")
                                                            select c.MWQMRunTVItemID).Distinct().Count();
                monitoringStatByYearRoutine.MWQMSampleCount = (from c in mwqmSampleList
                                                               where c.SampleDateTime_Local.Year == year
                                                               && c.SampleTypesText.Contains("109")
                                                               select c).Count();

                monitoringStatByYearRoutineSubsectorList.Add(monitoringStatByYearRoutine);
            }

            List<MonitoringStatByMonth> monitoringStatByMonthRoutineSubsectorList = new List<MonitoringStatByMonth>();

            for (int month = 1; month < 13; month++)
            {
                MonitoringStatByMonth monitoringStatByMonthRoutine = new MonitoringStatByMonth();
                monitoringStatByMonthRoutine.Month = (MonthEnum)month;
                monitoringStatByMonthRoutine.MWQMSiteCount = (from c in mwqmSampleList
                                                              where c.SampleDateTime_Local.Month == month
                                                              && c.SampleTypesText.Contains("109")
                                                              select c.MWQMSiteTVItemID).Distinct().Count();
                monitoringStatByMonthRoutine.MWQMRunCount = (from c in mwqmSampleList
                                                             where c.SampleDateTime_Local.Month == month
                                                             && c.SampleTypesText.Contains("109")
                                                             select c.MWQMRunTVItemID).Distinct().Count();
                monitoringStatByMonthRoutine.MWQMSampleCount = (from c in mwqmSampleList
                                                                where c.SampleDateTime_Local.Month == month
                                                                && c.SampleTypesText.Contains("109")
                                                                select c).Count();

                monitoringStatByMonthRoutineSubsectorList.Add(monitoringStatByMonthRoutine);
            }

            List<MonitoringStatBySeason> monitoringStatBySeasonRoutineSubsectorList = new List<MonitoringStatBySeason>();

            for (int season = 1; season < 5; season++)
            {
                MonitoringStatBySeason monitoringStatBySeasonRoutine = new MonitoringStatBySeason();
                monitoringStatBySeasonRoutine.Season = (SeasonEnum)season;

                switch ((SeasonEnum)season)
                {
                    case SeasonEnum.Winter:
                        {
                            monitoringStatBySeasonRoutine.MWQMSampleCount = (from c in mwqmSampleList
                                                                             where c.SampleTypesText.Contains("109,")
                                                                             && ((c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                             && c.SampleDateTime_Local.Day > 20)
                                                                             || c.SampleDateTime_Local.Month == (int)MonthEnum.January
                                                                             || c.SampleDateTime_Local.Month == (int)MonthEnum.February
                                                                             || (c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                             && c.SampleDateTime_Local.Day < 21))
                                                                             select c).Count();

                            monitoringStatBySeasonRoutine.MWQMSiteCount = (from c in mwqmSampleList
                                                                           where c.SampleTypesText.Contains("109,")
                                                                           && ((c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                           && c.SampleDateTime_Local.Day > 20)
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.January
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.February
                                                                           || (c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                           && c.SampleDateTime_Local.Day < 21))
                                                                           select c.MWQMSiteTVItemID).Distinct().Count();

                            monitoringStatBySeasonRoutine.MWQMRunCount = (from c in mwqmSampleList
                                                                          where c.SampleTypesText.Contains("109,")
                                                                          && ((c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                          && c.SampleDateTime_Local.Day > 20)
                                                                          || c.SampleDateTime_Local.Month == (int)MonthEnum.January
                                                                          || c.SampleDateTime_Local.Month == (int)MonthEnum.February
                                                                          || (c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                          && c.SampleDateTime_Local.Day < 21))
                                                                          select c.MWQMRunTVItemID).Distinct().Count();
                        }
                        break;
                    case SeasonEnum.Spring:
                        {
                            monitoringStatBySeasonRoutine.MWQMSampleCount = (from c in mwqmSampleList
                                                                             where c.SampleTypesText.Contains("109,")
                                                                             && ((c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                             && c.SampleDateTime_Local.Day > 20)
                                                                             || c.SampleDateTime_Local.Month == (int)MonthEnum.April
                                                                             || c.SampleDateTime_Local.Month == (int)MonthEnum.May
                                                                             || (c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                             && c.SampleDateTime_Local.Day < 21))
                                                                             select c).Count();

                            monitoringStatBySeasonRoutine.MWQMSiteCount = (from c in mwqmSampleList
                                                                           where c.SampleTypesText.Contains("109,")
                                                                           && ((c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                           && c.SampleDateTime_Local.Day > 20)
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.April
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.May
                                                                           || (c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                           && c.SampleDateTime_Local.Day < 21))
                                                                           select c.MWQMSiteTVItemID).Distinct().Count();

                            monitoringStatBySeasonRoutine.MWQMRunCount = (from c in mwqmSampleList
                                                                          where c.SampleTypesText.Contains("109,")
                                                                          && ((c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                          && c.SampleDateTime_Local.Day > 20)
                                                                          || c.SampleDateTime_Local.Month == (int)MonthEnum.April
                                                                          || c.SampleDateTime_Local.Month == (int)MonthEnum.May
                                                                          || (c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                          && c.SampleDateTime_Local.Day < 21))
                                                                          select c.MWQMRunTVItemID).Distinct().Count();
                        }
                        break;
                    case SeasonEnum.Summer:
                        {
                            monitoringStatBySeasonRoutine.MWQMSampleCount = (from c in mwqmSampleList
                                                                             where c.SampleTypesText.Contains("109,")
                                                                             && ((c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                             && c.SampleDateTime_Local.Day > 20)
                                                                             || c.SampleDateTime_Local.Month == (int)MonthEnum.July
                                                                             || c.SampleDateTime_Local.Month == (int)MonthEnum.August
                                                                             || (c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                             && c.SampleDateTime_Local.Day < 21))
                                                                             select c).Count();

                            monitoringStatBySeasonRoutine.MWQMSiteCount = (from c in mwqmSampleList
                                                                           where c.SampleTypesText.Contains("109,")
                                                                           && ((c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                           && c.SampleDateTime_Local.Day > 20)
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.July
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.August
                                                                           || (c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                           && c.SampleDateTime_Local.Day < 21))
                                                                           select c.MWQMSiteTVItemID).Distinct().Count();

                            monitoringStatBySeasonRoutine.MWQMRunCount = (from c in mwqmSampleList
                                                                          where c.SampleTypesText.Contains("109,")
                                                                          && ((c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                          && c.SampleDateTime_Local.Day > 20)
                                                                          || c.SampleDateTime_Local.Month == (int)MonthEnum.July
                                                                          || c.SampleDateTime_Local.Month == (int)MonthEnum.August
                                                                          || (c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                          && c.SampleDateTime_Local.Day < 21))
                                                                          select c.MWQMRunTVItemID).Distinct().Count();
                        }
                        break;
                    case SeasonEnum.Fall:
                        {
                            monitoringStatBySeasonRoutine.MWQMSampleCount = (from c in mwqmSampleList
                                                                             where c.SampleTypesText.Contains("109,")
                                                                             && ((c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                             && c.SampleDateTime_Local.Day > 20)
                                                                             || c.SampleDateTime_Local.Month == (int)MonthEnum.October
                                                                             || c.SampleDateTime_Local.Month == (int)MonthEnum.November
                                                                             || (c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                             && c.SampleDateTime_Local.Day < 21))
                                                                             select c).Count();

                            monitoringStatBySeasonRoutine.MWQMSiteCount = (from c in mwqmSampleList
                                                                           where c.SampleTypesText.Contains("109,")
                                                                           && ((c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                           && c.SampleDateTime_Local.Day > 20)
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.October
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.November
                                                                           || (c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                           && c.SampleDateTime_Local.Day < 21))
                                                                           select c.MWQMSiteTVItemID).Distinct().Count();

                            monitoringStatBySeasonRoutine.MWQMRunCount = (from c in mwqmSampleList
                                                                          where c.SampleTypesText.Contains("109,")
                                                                          && ((c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                          && c.SampleDateTime_Local.Day > 20)
                                                                          || c.SampleDateTime_Local.Month == (int)MonthEnum.October
                                                                          || c.SampleDateTime_Local.Month == (int)MonthEnum.November
                                                                          || (c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                          && c.SampleDateTime_Local.Day < 21))
                                                                          select c.MWQMRunTVItemID).Distinct().Count();
                        }
                        break;
                    default:
                        {
                            monitoringStatBySeasonRoutine.MWQMSampleCount = -1;
                            monitoringStatBySeasonRoutine.MWQMSiteCount = -1;
                            monitoringStatBySeasonRoutine.MWQMRunCount = -1;
                        }
                        break;
                }

                monitoringStatBySeasonRoutineSubsectorList.Add(monitoringStatBySeasonRoutine);
            }

            webMonitoringRoutineStatsProvince.MonitoringStatsModelList.Add(new MonitoringStatsModel()
            {
                TVItemModel = new TVItemModel()
                {
                    TVItem = tvItemSubsector,
                    TVItemLanguageList = (from c in tvItemLanguageSubsectorList
                                          where c.TVItemID == tvItemSubsector.TVItemID
                                          select c).ToList()

                },
                MonitoringStatByYearList = monitoringStatByYearRoutineSubsectorList,
                MonitoringStatByMonthList = monitoringStatByMonthRoutineSubsectorList,
                MonitoringStatBySeasonList = monitoringStatBySeasonRoutineSubsectorList,
            });
        }

        // doing Sector ----------------------------------------------
        // -----------------------------------------------------------
        List<TVItem> tvItemSectorList = await GetTVItemAllChildrenListWithTVItemIDAsync(tvItemProv, TVTypeEnum.Sector);
        List<TVItemLanguage> tvItemLanguageSectorList = await GetTVItemLanguageAllChildrenListWithTVItemIDAsync(tvItemProv, TVTypeEnum.Sector);

        foreach (TVItem tvItemSector in tvItemSectorList)
        {
            List<MonitoringStatByYear> statByYearSectorRoutineList = new List<MonitoringStatByYear>();
            List<MonitoringStatByMonth> statByMonthSectorRoutineList = new List<MonitoringStatByMonth>();
            List<MonitoringStatBySeason> statBySeasonSectorRoutineList = new List<MonitoringStatBySeason>();

            List<MonitoringStatsModel> monitoringStatsModelRoutineList = (from c in webMonitoringRoutineStatsProvince.MonitoringStatsModelList
                                                                          where c.TVItemModel.TVItem.ParentID == tvItemSector.TVItemID
                                                                          select c).ToList();

            List<TVItemLanguage> TVItemLanguageSectorList = (from c in tvItemLanguageSectorList
                                                             where c.TVItemID == tvItemSector.TVItemID
                                                             select c).ToList();

            string TVTextSector = TVItemLanguageSectorList[CSSPCultureService.LangID].TVText;
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { TVTextSector } { DateTime.Now }");

            for (int year = DateTime.Now.Year; year >= 1980; year--)
            {
                MonitoringStatByYear statByYearSectorRoutine = new MonitoringStatByYear();
                statByYearSectorRoutine.Year = year;
                statByYearSectorRoutine.MWQMSiteCount = 0;
                statByYearSectorRoutine.MWQMRunCount = 0;
                statByYearSectorRoutine.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelRoutineList)
                {
                    MonitoringStatByYear statByYear = (from c in monitoringStatsModel.MonitoringStatByYearList
                                                       where c.Year == year
                                                       select c).FirstOrDefault();

                    statByYearSectorRoutine.MWQMSiteCount += statByYear.MWQMSiteCount;
                    statByYearSectorRoutine.MWQMRunCount += statByYear.MWQMRunCount;
                    statByYearSectorRoutine.MWQMSampleCount += statByYear.MWQMSampleCount;

                }

                statByYearSectorRoutineList.Add(statByYearSectorRoutine);
            }

            for (int month = 1; month < 13; month++)
            {
                MonitoringStatByMonth statByMonthSectorRoutine = new MonitoringStatByMonth();
                statByMonthSectorRoutine.Month = (MonthEnum)month;
                statByMonthSectorRoutine.MWQMSiteCount = 0;
                statByMonthSectorRoutine.MWQMRunCount = 0;
                statByMonthSectorRoutine.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelRoutineList)
                {
                    MonitoringStatByMonth statByMonth = (from c in monitoringStatsModel.MonitoringStatByMonthList
                                                         where c.Month == (MonthEnum)month
                                                         select c).FirstOrDefault();

                    statByMonthSectorRoutine.MWQMSiteCount += statByMonth.MWQMSiteCount;
                    statByMonthSectorRoutine.MWQMRunCount += statByMonth.MWQMRunCount;
                    statByMonthSectorRoutine.MWQMSampleCount += statByMonth.MWQMSampleCount;

                }

                statByMonthSectorRoutineList.Add(statByMonthSectorRoutine);
            }

            for (int season = 1; season < 5; season++)
            {
                MonitoringStatBySeason statBySeasonSectorRoutine = new MonitoringStatBySeason();
                statBySeasonSectorRoutine.Season = (SeasonEnum)season;
                statBySeasonSectorRoutine.MWQMSiteCount = 0;
                statBySeasonSectorRoutine.MWQMRunCount = 0;
                statBySeasonSectorRoutine.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelRoutineList)
                {
                    MonitoringStatBySeason statBySeason = (from c in monitoringStatsModel.MonitoringStatBySeasonList
                                                           where c.Season == (SeasonEnum)season
                                                           select c).FirstOrDefault();

                    statBySeasonSectorRoutine.MWQMSiteCount += statBySeason.MWQMSiteCount;
                    statBySeasonSectorRoutine.MWQMRunCount += statBySeason.MWQMRunCount;
                    statBySeasonSectorRoutine.MWQMSampleCount += statBySeason.MWQMSampleCount;

                }

                statBySeasonSectorRoutineList.Add(statBySeasonSectorRoutine);
            }

            webMonitoringRoutineStatsProvince.MonitoringStatsModelList.Add(new MonitoringStatsModel()
            {
                TVItemModel = new TVItemModel()
                {
                    TVItem = tvItemSector,
                    TVItemLanguageList = (from c in tvItemLanguageSectorList
                                          where c.TVItemID == tvItemSector.TVItemID
                                          select c).ToList()

                },
                MonitoringStatByYearList = statByYearSectorRoutineList,
                MonitoringStatByMonthList = statByMonthSectorRoutineList,
                MonitoringStatBySeasonList = statBySeasonSectorRoutineList,
            });
        }

        // doing Area ----------------------------------------------
        // -----------------------------------------------------------
        List<TVItem> tvItemAreaList = await GetTVItemAllChildrenListWithTVItemIDAsync(tvItemProv, TVTypeEnum.Area);
        List<TVItemLanguage> tvItemLanguageAreaList = await GetTVItemLanguageAllChildrenListWithTVItemIDAsync(tvItemProv, TVTypeEnum.Area);

        foreach (TVItem tvItemArea in tvItemAreaList)
        {
            List<MonitoringStatByYear> statByYearAreaRoutineList = new List<MonitoringStatByYear>();
            List<MonitoringStatByMonth> statByMonthAreaRoutineList = new List<MonitoringStatByMonth>();
            List<MonitoringStatBySeason> statBySeasonAreaRoutineList = new List<MonitoringStatBySeason>();

            List<MonitoringStatsModel> monitoringStatsModelRoutineList = (from c in webMonitoringRoutineStatsProvince.MonitoringStatsModelList
                                                                          where c.TVItemModel.TVItem.ParentID == tvItemArea.TVItemID
                                                                          select c).ToList();

            List<TVItemLanguage> TVItemLanguageAreaList = (from c in tvItemLanguageAreaList
                                                           where c.TVItemID == tvItemArea.TVItemID
                                                           select c).ToList();

            string TVTextArea = TVItemLanguageAreaList[CSSPCultureService.LangID].TVText;
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { TVTextArea } { DateTime.Now }");

            for (int year = DateTime.Now.Year; year >= 1980; year--)
            {
                MonitoringStatByYear statByYearAreaRoutine = new MonitoringStatByYear();
                statByYearAreaRoutine.Year = year;
                statByYearAreaRoutine.MWQMSiteCount = 0;
                statByYearAreaRoutine.MWQMRunCount = 0;
                statByYearAreaRoutine.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelRoutineList)
                {
                    MonitoringStatByYear statByYear = (from c in monitoringStatsModel.MonitoringStatByYearList
                                                       where c.Year == year
                                                       select c).FirstOrDefault();

                    statByYearAreaRoutine.MWQMSiteCount += statByYear.MWQMSiteCount;
                    statByYearAreaRoutine.MWQMRunCount += statByYear.MWQMRunCount;
                    statByYearAreaRoutine.MWQMSampleCount += statByYear.MWQMSampleCount;

                }

                statByYearAreaRoutineList.Add(statByYearAreaRoutine);
            }

            for (int month = 1; month < 13; month++)
            {
                MonitoringStatByMonth statByMonthAreaRoutine = new MonitoringStatByMonth();
                statByMonthAreaRoutine.Month = (MonthEnum)month;
                statByMonthAreaRoutine.MWQMSiteCount = 0;
                statByMonthAreaRoutine.MWQMRunCount = 0;
                statByMonthAreaRoutine.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelRoutineList)
                {
                    MonitoringStatByMonth statByMonth = (from c in monitoringStatsModel.MonitoringStatByMonthList
                                                         where c.Month == (MonthEnum)month
                                                         select c).FirstOrDefault();

                    statByMonthAreaRoutine.MWQMSiteCount += statByMonth.MWQMSiteCount;
                    statByMonthAreaRoutine.MWQMRunCount += statByMonth.MWQMRunCount;
                    statByMonthAreaRoutine.MWQMSampleCount += statByMonth.MWQMSampleCount;

                }

                statByMonthAreaRoutineList.Add(statByMonthAreaRoutine);
            }

            for (int season = 1; season < 5; season++)
            {
                MonitoringStatBySeason statBySeasonAreaRoutine = new MonitoringStatBySeason();
                statBySeasonAreaRoutine.Season = (SeasonEnum)season;
                statBySeasonAreaRoutine.MWQMSiteCount = 0;
                statBySeasonAreaRoutine.MWQMRunCount = 0;
                statBySeasonAreaRoutine.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelRoutineList)
                {
                    MonitoringStatBySeason statBySeason = (from c in monitoringStatsModel.MonitoringStatBySeasonList
                                                           where c.Season == (SeasonEnum)season
                                                           select c).FirstOrDefault();

                    statBySeasonAreaRoutine.MWQMSiteCount += statBySeason.MWQMSiteCount;
                    statBySeasonAreaRoutine.MWQMRunCount += statBySeason.MWQMRunCount;
                    statBySeasonAreaRoutine.MWQMSampleCount += statBySeason.MWQMSampleCount;

                }

                statBySeasonAreaRoutineList.Add(statBySeasonAreaRoutine);
            }

            webMonitoringRoutineStatsProvince.MonitoringStatsModelList.Add(new MonitoringStatsModel()
            {
                TVItemModel = new TVItemModel()
                {
                    TVItem = tvItemArea,
                    TVItemLanguageList = (from c in tvItemLanguageAreaList
                                          where c.TVItemID == tvItemArea.TVItemID
                                          select c).ToList()

                },
                MonitoringStatByYearList = statByYearAreaRoutineList,
                MonitoringStatByMonthList = statByMonthAreaRoutineList,
                MonitoringStatBySeasonList = statBySeasonAreaRoutineList,
            });
        }

        // doing Province ----------------------------------------------
        // -----------------------------------------------------------

        List<MonitoringStatByYear> statByYearProvinceRoutineList = new List<MonitoringStatByYear>();
        List<MonitoringStatByMonth> statByMonthProvinceRoutineList = new List<MonitoringStatByMonth>();
        List<MonitoringStatBySeason> statBySeasonProvinceRoutineList = new List<MonitoringStatBySeason>();

        List<MonitoringStatsModel> monitoringStatsModelProvinceRoutineList = (from c in webMonitoringRoutineStatsProvince.MonitoringStatsModelList
                                                                              where c.TVItemModel.TVItem.ParentID == tvItemProv.TVItemID
                                                                              select c).ToList();
        List<TVItemLanguage> TVItemLanguageProvinceList = (from c in tvItemLanguageProvinceTestList
                                                           where c.TVItemID == ProvinceTVItemID
                                                           select c).ToList();

        string TVTextProvince = TVItemLanguageProvinceList[CSSPCultureService.LangID].TVText;
        CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { TVTextProvince } { DateTime.Now }");

        for (int year = DateTime.Now.Year; year >= 1980; year--)
        {
            MonitoringStatByYear statByYearProvinceRoutine = new MonitoringStatByYear();
            statByYearProvinceRoutine.Year = year;
            statByYearProvinceRoutine.MWQMSiteCount = 0;
            statByYearProvinceRoutine.MWQMRunCount = 0;
            statByYearProvinceRoutine.MWQMSampleCount = 0;

            foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelProvinceRoutineList)
            {
                MonitoringStatByYear statByYear = (from c in monitoringStatsModel.MonitoringStatByYearList
                                                   where c.Year == year
                                                   select c).FirstOrDefault();

                statByYearProvinceRoutine.MWQMSiteCount += statByYear.MWQMSiteCount;
                statByYearProvinceRoutine.MWQMRunCount += statByYear.MWQMRunCount;
                statByYearProvinceRoutine.MWQMSampleCount += statByYear.MWQMSampleCount;

            }

            statByYearProvinceRoutineList.Add(statByYearProvinceRoutine);
        }

        for (int month = 1; month < 13; month++)
        {
            MonitoringStatByMonth statByMonthProvinceRoutine = new MonitoringStatByMonth();
            statByMonthProvinceRoutine.Month = (MonthEnum)month;
            statByMonthProvinceRoutine.MWQMSiteCount = 0;
            statByMonthProvinceRoutine.MWQMRunCount = 0;
            statByMonthProvinceRoutine.MWQMSampleCount = 0;

            foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelProvinceRoutineList)
            {
                MonitoringStatByMonth statByMonth = (from c in monitoringStatsModel.MonitoringStatByMonthList
                                                     where c.Month == (MonthEnum)month
                                                     select c).FirstOrDefault();

                statByMonthProvinceRoutine.MWQMSiteCount += statByMonth.MWQMSiteCount;
                statByMonthProvinceRoutine.MWQMRunCount += statByMonth.MWQMRunCount;
                statByMonthProvinceRoutine.MWQMSampleCount += statByMonth.MWQMSampleCount;

            }

            statByMonthProvinceRoutineList.Add(statByMonthProvinceRoutine);
        }

        for (int season = 1; season < 5; season++)
        {
            MonitoringStatBySeason statBySeasonProvinceRoutine = new MonitoringStatBySeason();
            statBySeasonProvinceRoutine.Season = (SeasonEnum)season;
            statBySeasonProvinceRoutine.MWQMSiteCount = 0;
            statBySeasonProvinceRoutine.MWQMRunCount = 0;
            statBySeasonProvinceRoutine.MWQMSampleCount = 0;

            foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelProvinceRoutineList)
            {
                MonitoringStatBySeason statBySeason = (from c in monitoringStatsModel.MonitoringStatBySeasonList
                                                       where c.Season == (SeasonEnum)season
                                                       select c).FirstOrDefault();

                statBySeasonProvinceRoutine.MWQMSiteCount += statBySeason.MWQMSiteCount;
                statBySeasonProvinceRoutine.MWQMRunCount += statBySeason.MWQMRunCount;
                statBySeasonProvinceRoutine.MWQMSampleCount += statBySeason.MWQMSampleCount;

            }

            statBySeasonProvinceRoutineList.Add(statBySeasonProvinceRoutine);
        }

        webMonitoringRoutineStatsProvince.MonitoringStatsModelList.Add(new MonitoringStatsModel()
        {
            TVItemModel = new TVItemModel()
            {
                TVItem = tvItemProv,
                TVItemLanguageList = (from c in tvItemLanguageProvList
                                      where c.TVItemID == tvItemProv.TVItemID
                                      select c).ToList()

            },
            MonitoringStatByYearList = statByYearProvinceRoutineList,
            MonitoringStatByMonthList = statByMonthProvinceRoutineList,
            MonitoringStatBySeasonList = statBySeasonProvinceRoutineList,
        });

        try
        {
            if (Local)
            {
                if (!await StoreLocalAsync<WebMonitoringRoutineStatsProvince>(webMonitoringRoutineStatsProvince, $"{ WebTypeEnum.WebMonitoringRoutineStatsProvince }_{tvItemProv.TVItemID}.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebMonitoringRoutineStatsProvince>(webMonitoringRoutineStatsProvince, $"{ WebTypeEnum.WebMonitoringRoutineStatsProvince }_{tvItemProv.TVItemID}.gz")) return await Task.FromResult(false);
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

