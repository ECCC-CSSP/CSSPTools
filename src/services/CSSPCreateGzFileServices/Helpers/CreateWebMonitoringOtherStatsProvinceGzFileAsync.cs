namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebMonitoringOtherStatsProvinceGzFileAsync(int ProvinceTVItemID)
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

        WebMonitoringOtherStatsProvince webMonitoringOtherStatsProvince = new WebMonitoringOtherStatsProvince();

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

            List<MonitoringStatByYear> monitoringStatByYearOtherSubsectorList = new List<MonitoringStatByYear>();

            for (int year = DateTime.Now.Year; year >= 1980; year--)
            {
                MonitoringStatByYear monitoringStatByYearOther = new MonitoringStatByYear();
                monitoringStatByYearOther.Year = year;
                monitoringStatByYearOther.MWQMSiteCount = (from c in mwqmSampleList
                                                           where c.SampleDateTime_Local.Year == year
                                                           && !c.SampleTypesText.Contains("109")
                                                           select c.MWQMSiteTVItemID).Distinct().Count();
                monitoringStatByYearOther.MWQMRunCount = (from c in mwqmSampleList
                                                          where c.SampleDateTime_Local.Year == year
                                                          && !c.SampleTypesText.Contains("109")
                                                          select c.MWQMRunTVItemID).Distinct().Count();
                monitoringStatByYearOther.MWQMSampleCount = (from c in mwqmSampleList
                                                             where c.SampleDateTime_Local.Year == year
                                                             && !c.SampleTypesText.Contains("109")
                                                             select c).Count();

                monitoringStatByYearOtherSubsectorList.Add(monitoringStatByYearOther);
            }

            List<MonitoringStatByMonth> monitoringStatByMonthOtherSubsectorList = new List<MonitoringStatByMonth>();

            for (int month = 1; month < 13; month++)
            {
                MonitoringStatByMonth monitoringStatByMonthOther = new MonitoringStatByMonth();
                monitoringStatByMonthOther.Month = (MonthEnum)month;
                monitoringStatByMonthOther.MWQMSiteCount = (from c in mwqmSampleList
                                                            where c.SampleDateTime_Local.Month == month
                                                            && !c.SampleTypesText.Contains("109")
                                                            select c.MWQMSiteTVItemID).Distinct().Count();
                monitoringStatByMonthOther.MWQMRunCount = (from c in mwqmSampleList
                                                           where c.SampleDateTime_Local.Month == month
                                                           && !c.SampleTypesText.Contains("109")
                                                           select c.MWQMRunTVItemID).Distinct().Count();
                monitoringStatByMonthOther.MWQMSampleCount = (from c in mwqmSampleList
                                                              where c.SampleDateTime_Local.Month == month
                                                              && !c.SampleTypesText.Contains("109")
                                                              select c).Count();

                monitoringStatByMonthOtherSubsectorList.Add(monitoringStatByMonthOther);
            }

            List<MonitoringStatBySeason> monitoringStatBySeasonOtherSubsectorList = new List<MonitoringStatBySeason>();

            for (int season = 1; season < 5; season++)
            {
                MonitoringStatBySeason monitoringStatBySeasonOther = new MonitoringStatBySeason();
                monitoringStatBySeasonOther.Season = (SeasonEnum)season;

                switch ((SeasonEnum)season)
                {
                    case SeasonEnum.Winter:
                        {
                            monitoringStatBySeasonOther.MWQMSampleCount = (from c in mwqmSampleList
                                                                           where !c.SampleTypesText.Contains("109,")
                                                                           && ((c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                           && c.SampleDateTime_Local.Day > 20)
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.January
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.February
                                                                           && (c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                           && c.SampleDateTime_Local.Day < 21))
                                                                           select c).Count();

                            monitoringStatBySeasonOther.MWQMSiteCount = (from c in mwqmSampleList
                                                                         where !c.SampleTypesText.Contains("109,")
                                                                         && ((c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                         && c.SampleDateTime_Local.Day > 20)
                                                                         || c.SampleDateTime_Local.Month == (int)MonthEnum.January
                                                                         || c.SampleDateTime_Local.Month == (int)MonthEnum.February
                                                                         && (c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                         && c.SampleDateTime_Local.Day < 21))
                                                                         select c.MWQMSiteTVItemID).Distinct().Count();

                            monitoringStatBySeasonOther.MWQMRunCount = (from c in mwqmSampleList
                                                                        where !c.SampleTypesText.Contains("109,")
                                                                        && ((c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                        && c.SampleDateTime_Local.Day > 20)
                                                                        || c.SampleDateTime_Local.Month == (int)MonthEnum.January
                                                                        || c.SampleDateTime_Local.Month == (int)MonthEnum.February
                                                                        && (c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                        && c.SampleDateTime_Local.Day < 21))
                                                                        select c.MWQMRunTVItemID).Distinct().Count();
                        }
                        break;
                    case SeasonEnum.Spring:
                        {
                            monitoringStatBySeasonOther.MWQMSampleCount = (from c in mwqmSampleList
                                                                           where !c.SampleTypesText.Contains("109,")
                                                                           && ((c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                           && c.SampleDateTime_Local.Day > 20)
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.April
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.May
                                                                           && (c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                           && c.SampleDateTime_Local.Day < 21))
                                                                           select c).Count();

                            monitoringStatBySeasonOther.MWQMSiteCount = (from c in mwqmSampleList
                                                                         where !c.SampleTypesText.Contains("109,")
                                                                         && ((c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                         && c.SampleDateTime_Local.Day > 20)
                                                                         || c.SampleDateTime_Local.Month == (int)MonthEnum.April
                                                                         || c.SampleDateTime_Local.Month == (int)MonthEnum.May
                                                                         && (c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                         && c.SampleDateTime_Local.Day < 21))
                                                                         select c.MWQMSiteTVItemID).Distinct().Count();

                            monitoringStatBySeasonOther.MWQMRunCount = (from c in mwqmSampleList
                                                                        where !c.SampleTypesText.Contains("109,")
                                                                        && ((c.SampleDateTime_Local.Month == (int)MonthEnum.March
                                                                        && c.SampleDateTime_Local.Day > 20)
                                                                        || c.SampleDateTime_Local.Month == (int)MonthEnum.April
                                                                        || c.SampleDateTime_Local.Month == (int)MonthEnum.May
                                                                        && (c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                        && c.SampleDateTime_Local.Day < 21))
                                                                        select c.MWQMRunTVItemID).Distinct().Count();
                        }
                        break;
                    case SeasonEnum.Summer:
                        {
                            monitoringStatBySeasonOther.MWQMSampleCount = (from c in mwqmSampleList
                                                                           where !c.SampleTypesText.Contains("109,")
                                                                           && ((c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                           && c.SampleDateTime_Local.Day > 20)
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.July
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.August
                                                                           && (c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                           && c.SampleDateTime_Local.Day < 21))
                                                                           select c).Count();

                            monitoringStatBySeasonOther.MWQMSiteCount = (from c in mwqmSampleList
                                                                         where !c.SampleTypesText.Contains("109,")
                                                                         && ((c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                         && c.SampleDateTime_Local.Day > 20)
                                                                         || c.SampleDateTime_Local.Month == (int)MonthEnum.July
                                                                         || c.SampleDateTime_Local.Month == (int)MonthEnum.August
                                                                         && (c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                         && c.SampleDateTime_Local.Day < 21))
                                                                         select c.MWQMSiteTVItemID).Distinct().Count();

                            monitoringStatBySeasonOther.MWQMRunCount = (from c in mwqmSampleList
                                                                        where !c.SampleTypesText.Contains("109,")
                                                                        && ((c.SampleDateTime_Local.Month == (int)MonthEnum.June
                                                                        && c.SampleDateTime_Local.Day > 20)
                                                                        || c.SampleDateTime_Local.Month == (int)MonthEnum.July
                                                                        || c.SampleDateTime_Local.Month == (int)MonthEnum.August
                                                                        && (c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                        && c.SampleDateTime_Local.Day < 21))
                                                                        select c.MWQMRunTVItemID).Distinct().Count();
                        }
                        break;
                    case SeasonEnum.Fall:
                        {
                            monitoringStatBySeasonOther.MWQMSampleCount = (from c in mwqmSampleList
                                                                           where !c.SampleTypesText.Contains("109,")
                                                                           && ((c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                           && c.SampleDateTime_Local.Day > 20)
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.October
                                                                           || c.SampleDateTime_Local.Month == (int)MonthEnum.November
                                                                           && (c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                           && c.SampleDateTime_Local.Day < 21))
                                                                           select c).Count();

                            monitoringStatBySeasonOther.MWQMSiteCount = (from c in mwqmSampleList
                                                                         where !c.SampleTypesText.Contains("109,")
                                                                         && ((c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                         && c.SampleDateTime_Local.Day > 20)
                                                                         || c.SampleDateTime_Local.Month == (int)MonthEnum.October
                                                                         || c.SampleDateTime_Local.Month == (int)MonthEnum.November
                                                                         && (c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                         && c.SampleDateTime_Local.Day < 21))
                                                                         select c.MWQMSiteTVItemID).Distinct().Count();

                            monitoringStatBySeasonOther.MWQMRunCount = (from c in mwqmSampleList
                                                                        where !c.SampleTypesText.Contains("109,")
                                                                        && ((c.SampleDateTime_Local.Month == (int)MonthEnum.September
                                                                        && c.SampleDateTime_Local.Day > 20)
                                                                        || c.SampleDateTime_Local.Month == (int)MonthEnum.October
                                                                        || c.SampleDateTime_Local.Month == (int)MonthEnum.November
                                                                        && (c.SampleDateTime_Local.Month == (int)MonthEnum.December
                                                                        && c.SampleDateTime_Local.Day < 21))
                                                                        select c.MWQMRunTVItemID).Distinct().Count();
                        }
                        break;
                    default:
                        {
                            monitoringStatBySeasonOther.MWQMSampleCount = -1;
                            monitoringStatBySeasonOther.MWQMSiteCount = -1;
                            monitoringStatBySeasonOther.MWQMRunCount = -1;
                        }
                        break;
                }

                monitoringStatBySeasonOtherSubsectorList.Add(monitoringStatBySeasonOther);
            }

            webMonitoringOtherStatsProvince.MonitoringStatsModelList.Add(new MonitoringStatsModel()
            {
                TVItemModel = new TVItemModel()
                {
                    TVItem = tvItemSubsector,
                    TVItemLanguageList = (from c in tvItemLanguageSubsectorList
                                          where c.TVItemID == tvItemSubsector.TVItemID
                                          select c).ToList()

                },
                MonitoringStatByYearList = monitoringStatByYearOtherSubsectorList,
                MonitoringStatByMonthList = monitoringStatByMonthOtherSubsectorList,
                MonitoringStatBySeasonList = monitoringStatBySeasonOtherSubsectorList,
            });
        }

        // doing Sector ----------------------------------------------
        // -----------------------------------------------------------
        List<TVItem> tvItemSectorList = await GetTVItemAllChildrenListWithTVItemIDAsync(tvItemProv, TVTypeEnum.Sector);
        List<TVItemLanguage> tvItemLanguageSectorList = await GetTVItemLanguageAllChildrenListWithTVItemIDAsync(tvItemProv, TVTypeEnum.Sector);

        foreach (TVItem tvItemSector in tvItemSectorList)
        {
            List<MonitoringStatByYear> statByYearSectorOtherList = new List<MonitoringStatByYear>();
            List<MonitoringStatByMonth> statByMonthSectorOtherList = new List<MonitoringStatByMonth>();
            List<MonitoringStatBySeason> statBySeasonSectorOtherList = new List<MonitoringStatBySeason>();

            List<MonitoringStatsModel> monitoringStatsModelOtherList = (from c in webMonitoringOtherStatsProvince.MonitoringStatsModelList
                                                                        where c.TVItemModel.TVItem.ParentID == tvItemSector.TVItemID
                                                                        select c).ToList();

            List<TVItemLanguage> TVItemLanguageSectorList = (from c in tvItemLanguageSectorList
                                                             where c.TVItemID == tvItemSector.TVItemID
                                                             select c).ToList();

            string TVTextSector = TVItemLanguageSectorList[CSSPCultureService.LangID].TVText;
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { TVTextSector } { DateTime.Now }");

            for (int year = DateTime.Now.Year; year >= 1980; year--)
            {
                MonitoringStatByYear statByYearSectorOther = new MonitoringStatByYear();
                statByYearSectorOther.Year = year;
                statByYearSectorOther.MWQMSiteCount = 0;
                statByYearSectorOther.MWQMRunCount = 0;
                statByYearSectorOther.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelOtherList)
                {
                    MonitoringStatByYear statByYear = (from c in monitoringStatsModel.MonitoringStatByYearList
                                                       where c.Year == year
                                                       select c).FirstOrDefault();

                    statByYearSectorOther.MWQMSiteCount += statByYear.MWQMSiteCount;
                    statByYearSectorOther.MWQMRunCount += statByYear.MWQMRunCount;
                    statByYearSectorOther.MWQMSampleCount += statByYear.MWQMSampleCount;

                }

                statByYearSectorOtherList.Add(statByYearSectorOther);
            }

            for (int month = 1; month < 13; month++)
            {
                MonitoringStatByMonth statByMonthSectorOther = new MonitoringStatByMonth();
                statByMonthSectorOther.Month = (MonthEnum)month;
                statByMonthSectorOther.MWQMSiteCount = 0;
                statByMonthSectorOther.MWQMRunCount = 0;
                statByMonthSectorOther.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelOtherList)
                {
                    MonitoringStatByMonth statByMonth = (from c in monitoringStatsModel.MonitoringStatByMonthList
                                                         where c.Month == (MonthEnum)month
                                                         select c).FirstOrDefault();

                    statByMonthSectorOther.MWQMSiteCount += statByMonth.MWQMSiteCount;
                    statByMonthSectorOther.MWQMRunCount += statByMonth.MWQMRunCount;
                    statByMonthSectorOther.MWQMSampleCount += statByMonth.MWQMSampleCount;

                }

                statByMonthSectorOtherList.Add(statByMonthSectorOther);
            }

            for (int season = 1; season < 5; season++)
            {
                MonitoringStatBySeason statBySeasonSectorOther = new MonitoringStatBySeason();
                statBySeasonSectorOther.Season = (SeasonEnum)season;
                statBySeasonSectorOther.MWQMSiteCount = 0;
                statBySeasonSectorOther.MWQMRunCount = 0;
                statBySeasonSectorOther.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelOtherList)
                {
                    MonitoringStatBySeason statBySeason = (from c in monitoringStatsModel.MonitoringStatBySeasonList
                                                           where c.Season == (SeasonEnum)season
                                                           select c).FirstOrDefault();

                    statBySeasonSectorOther.MWQMSiteCount += statBySeason.MWQMSiteCount;
                    statBySeasonSectorOther.MWQMRunCount += statBySeason.MWQMRunCount;
                    statBySeasonSectorOther.MWQMSampleCount += statBySeason.MWQMSampleCount;

                }

                statBySeasonSectorOtherList.Add(statBySeasonSectorOther);
            }

            webMonitoringOtherStatsProvince.MonitoringStatsModelList.Add(new MonitoringStatsModel()
            {
                TVItemModel = new TVItemModel()
                {
                    TVItem = tvItemSector,
                    TVItemLanguageList = (from c in tvItemLanguageSectorList
                                          where c.TVItemID == tvItemSector.TVItemID
                                          select c).ToList()

                },
                MonitoringStatByYearList = statByYearSectorOtherList,
                MonitoringStatByMonthList = statByMonthSectorOtherList,
                MonitoringStatBySeasonList = statBySeasonSectorOtherList,
            });
        }

        // doing Area ----------------------------------------------
        // -----------------------------------------------------------
        List<TVItem> tvItemAreaList = await GetTVItemAllChildrenListWithTVItemIDAsync(tvItemProv, TVTypeEnum.Area);
        List<TVItemLanguage> tvItemLanguageAreaList = await GetTVItemLanguageAllChildrenListWithTVItemIDAsync(tvItemProv, TVTypeEnum.Area);

        foreach (TVItem tvItemArea in tvItemAreaList)
        {
            List<MonitoringStatByYear> statByYearAreaOtherList = new List<MonitoringStatByYear>();
            List<MonitoringStatByMonth> statByMonthAreaOtherList = new List<MonitoringStatByMonth>();
            List<MonitoringStatBySeason> statBySeasonAreaOtherList = new List<MonitoringStatBySeason>();

            List<MonitoringStatsModel> monitoringStatsModelOtherList = (from c in webMonitoringOtherStatsProvince.MonitoringStatsModelList
                                                                        where c.TVItemModel.TVItem.ParentID == tvItemArea.TVItemID
                                                                        select c).ToList();

            List<TVItemLanguage> TVItemLanguageAreaList = (from c in tvItemLanguageAreaList
                                                           where c.TVItemID == tvItemArea.TVItemID
                                                           select c).ToList();

            string TVTextArea = TVItemLanguageAreaList[CSSPCultureService.LangID].TVText;
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { TVTextArea } { DateTime.Now }");

            for (int year = DateTime.Now.Year; year >= 1980; year--)
            {
                MonitoringStatByYear statByYearAreaOther = new MonitoringStatByYear();
                statByYearAreaOther.Year = year;
                statByYearAreaOther.MWQMSiteCount = 0;
                statByYearAreaOther.MWQMRunCount = 0;
                statByYearAreaOther.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelOtherList)
                {
                    MonitoringStatByYear statByYear = (from c in monitoringStatsModel.MonitoringStatByYearList
                                                       where c.Year == year
                                                       select c).FirstOrDefault();

                    statByYearAreaOther.MWQMSiteCount += statByYear.MWQMSiteCount;
                    statByYearAreaOther.MWQMRunCount += statByYear.MWQMRunCount;
                    statByYearAreaOther.MWQMSampleCount += statByYear.MWQMSampleCount;

                }

                statByYearAreaOtherList.Add(statByYearAreaOther);
            }

            for (int month = 1; month < 13; month++)
            {
                MonitoringStatByMonth statByMonthAreaOther = new MonitoringStatByMonth();
                statByMonthAreaOther.Month = (MonthEnum)month;
                statByMonthAreaOther.MWQMSiteCount = 0;
                statByMonthAreaOther.MWQMRunCount = 0;
                statByMonthAreaOther.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelOtherList)
                {
                    MonitoringStatByMonth statByMonth = (from c in monitoringStatsModel.MonitoringStatByMonthList
                                                         where c.Month == (MonthEnum)month
                                                         select c).FirstOrDefault();

                    statByMonthAreaOther.MWQMSiteCount += statByMonth.MWQMSiteCount;
                    statByMonthAreaOther.MWQMRunCount += statByMonth.MWQMRunCount;
                    statByMonthAreaOther.MWQMSampleCount += statByMonth.MWQMSampleCount;

                }

                statByMonthAreaOtherList.Add(statByMonthAreaOther);
            }

            for (int season = 1; season < 5; season++)
            {
                MonitoringStatBySeason statBySeasonAreaOther = new MonitoringStatBySeason();
                statBySeasonAreaOther.Season = (SeasonEnum)season;
                statBySeasonAreaOther.MWQMSiteCount = 0;
                statBySeasonAreaOther.MWQMRunCount = 0;
                statBySeasonAreaOther.MWQMSampleCount = 0;

                foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelOtherList)
                {
                    MonitoringStatBySeason statBySeason = (from c in monitoringStatsModel.MonitoringStatBySeasonList
                                                           where c.Season == (SeasonEnum)season
                                                           select c).FirstOrDefault();

                    statBySeasonAreaOther.MWQMSiteCount += statBySeason.MWQMSiteCount;
                    statBySeasonAreaOther.MWQMRunCount += statBySeason.MWQMRunCount;
                    statBySeasonAreaOther.MWQMSampleCount += statBySeason.MWQMSampleCount;

                }

                statBySeasonAreaOtherList.Add(statBySeasonAreaOther);
            }

            webMonitoringOtherStatsProvince.MonitoringStatsModelList.Add(new MonitoringStatsModel()
            {
                TVItemModel = new TVItemModel()
                {
                    TVItem = tvItemArea,
                    TVItemLanguageList = (from c in tvItemLanguageAreaList
                                          where c.TVItemID == tvItemArea.TVItemID
                                          select c).ToList()

                },
                MonitoringStatByYearList = statByYearAreaOtherList,
                MonitoringStatByMonthList = statByMonthAreaOtherList,
                MonitoringStatBySeasonList = statBySeasonAreaOtherList,
            });
        }

        // doing Province ----------------------------------------------
        // -----------------------------------------------------------

        List<MonitoringStatByYear> statByYearProvinceOtherList = new List<MonitoringStatByYear>();
        List<MonitoringStatByMonth> statByMonthProvinceOtherList = new List<MonitoringStatByMonth>();
        List<MonitoringStatBySeason> statBySeasonProvinceOtherList = new List<MonitoringStatBySeason>();

        List<MonitoringStatsModel> monitoringStatsModelProvinceOtherList = (from c in webMonitoringOtherStatsProvince.MonitoringStatsModelList
                                                                            where c.TVItemModel.TVItem.ParentID == tvItemProv.TVItemID
                                                                            select c).ToList();

        List<TVItemLanguage> TVItemLanguageProvinceList = (from c in tvItemLanguageProvinceTestList
                                                           where c.TVItemID == ProvinceTVItemID
                                                           select c).ToList();

        string TVTextProvince = TVItemLanguageProvinceList[CSSPCultureService.LangID].TVText;
        CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Doing } { TVTextProvince } { DateTime.Now }");

        for (int year = DateTime.Now.Year; year >= 1980; year--)
        {
            MonitoringStatByYear statByYearProvinceOther = new MonitoringStatByYear();
            statByYearProvinceOther.Year = year;
            statByYearProvinceOther.MWQMSiteCount = 0;
            statByYearProvinceOther.MWQMRunCount = 0;
            statByYearProvinceOther.MWQMSampleCount = 0;

            foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelProvinceOtherList)
            {
                MonitoringStatByYear statByYear = (from c in monitoringStatsModel.MonitoringStatByYearList
                                                   where c.Year == year
                                                   select c).FirstOrDefault();

                statByYearProvinceOther.MWQMSiteCount += statByYear.MWQMSiteCount;
                statByYearProvinceOther.MWQMRunCount += statByYear.MWQMRunCount;
                statByYearProvinceOther.MWQMSampleCount += statByYear.MWQMSampleCount;

            }

            statByYearProvinceOtherList.Add(statByYearProvinceOther);
        }

        for (int month = 1; month < 13; month++)
        {
            MonitoringStatByMonth statByMonthProvinceOther = new MonitoringStatByMonth();
            statByMonthProvinceOther.Month = (MonthEnum)month;
            statByMonthProvinceOther.MWQMSiteCount = 0;
            statByMonthProvinceOther.MWQMRunCount = 0;
            statByMonthProvinceOther.MWQMSampleCount = 0;

            foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelProvinceOtherList)
            {
                MonitoringStatByMonth statByMonth = (from c in monitoringStatsModel.MonitoringStatByMonthList
                                                     where c.Month == (MonthEnum)month
                                                     select c).FirstOrDefault();

                statByMonthProvinceOther.MWQMSiteCount += statByMonth.MWQMSiteCount;
                statByMonthProvinceOther.MWQMRunCount += statByMonth.MWQMRunCount;
                statByMonthProvinceOther.MWQMSampleCount += statByMonth.MWQMSampleCount;

            }

            statByMonthProvinceOtherList.Add(statByMonthProvinceOther);
        }

        for (int season = 1; season < 5; season++)
        {
            MonitoringStatBySeason statBySeasonProvinceOther = new MonitoringStatBySeason();
            statBySeasonProvinceOther.Season = (SeasonEnum)season;
            statBySeasonProvinceOther.MWQMSiteCount = 0;
            statBySeasonProvinceOther.MWQMRunCount = 0;
            statBySeasonProvinceOther.MWQMSampleCount = 0;

            foreach (MonitoringStatsModel monitoringStatsModel in monitoringStatsModelProvinceOtherList)
            {
                MonitoringStatBySeason statBySeason = (from c in monitoringStatsModel.MonitoringStatBySeasonList
                                                       where c.Season == (SeasonEnum)season
                                                       select c).FirstOrDefault();

                statBySeasonProvinceOther.MWQMSiteCount += statBySeason.MWQMSiteCount;
                statBySeasonProvinceOther.MWQMRunCount += statBySeason.MWQMRunCount;
                statBySeasonProvinceOther.MWQMSampleCount += statBySeason.MWQMSampleCount;

            }

            statBySeasonProvinceOtherList.Add(statBySeasonProvinceOther);
        }

        webMonitoringOtherStatsProvince.MonitoringStatsModelList.Add(new MonitoringStatsModel()
        {
            TVItemModel = new TVItemModel()
            {
                TVItem = tvItemProv,
                TVItemLanguageList = (from c in tvItemLanguageProvList
                                      where c.TVItemID == tvItemProv.TVItemID
                                      select c).ToList()

            },
            MonitoringStatByYearList = statByYearProvinceOtherList,
            MonitoringStatByMonthList = statByMonthProvinceOtherList,
            MonitoringStatBySeasonList = statBySeasonProvinceOtherList,
        });

        try
        {
            if (Local)
            {
                if (!await StoreLocalAsync<WebMonitoringOtherStatsProvince>(webMonitoringOtherStatsProvince, $"{ WebTypeEnum.WebMonitoringOtherStatsProvince }_{tvItemProv.TVItemID}.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebMonitoringOtherStatsProvince>(webMonitoringOtherStatsProvince, $"{ WebTypeEnum.WebMonitoringOtherStatsProvince }_{tvItemProv.TVItemID}.gz")) return await Task.FromResult(false);
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

