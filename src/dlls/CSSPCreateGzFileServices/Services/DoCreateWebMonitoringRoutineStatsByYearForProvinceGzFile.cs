﻿/*
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
        private async Task<ActionResult<bool>> DoCreateWebMonitoringRoutineStatsByYearForProvinceGzFile(int ProvinceTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem tvItemRoot = await GetTVItemRoot();

            TVItem tvItemTest = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (tvItemTest == null || tvItemTest.TVType != TVTypeEnum.Province)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_,
                    "TVItem", "TVType", TVTypeEnum.Province.ToString())));
            }

            TVItem tvItemProv = await GetTVItemWithTVItemID(ProvinceTVItemID);
            List<TVItemLanguage> tvItemLanguageProvList = await GetTVItemLanguageWithTVItemID(ProvinceTVItemID);

            WebMonitoringRoutineStatsByYearForProvince webMonitoringRoutineStatsByYearForProvince = new WebMonitoringRoutineStatsByYearForProvince();

            List<TVItem> tvItemSubsectorList = await GetTVItemAllChildrenListWithTVItemID(tvItemProv, TVTypeEnum.Subsector);
            List<TVItemLanguage> tvItemLanguageSubsectorList = await GetTVItemLanguageAllChildrenListWithTVItemID(tvItemProv, TVTypeEnum.Subsector);

            // doing Subsector -------------------------------------------
            // -----------------------------------------------------------
            foreach (TVItem tvItemSubsector in tvItemSubsectorList)
            {
                string TVText = (from c in tvItemLanguageSubsectorList
                                 where c.TVItemID == tvItemSubsector.TVItemID
                                 && c.Language == LanguageEnum.en
                                 select c.TVText).FirstOrDefault();

                Console.WriteLine($"Reading subsector {TVText}...");

                string subsector = TVText;

                if (subsector.Contains(" "))
                {
                    subsector = TVText.Substring(0, TVText.IndexOf(" "));
                }

                List<MWQMSample> mwqmSampleList = await GetMWQMSampleListUnderSubsector(tvItemSubsector);

                List<StatByYear> statByYearRoutineSubsectorList = new List<StatByYear>();

                for (int j = DateTime.Now.Year; j >= 1980; j--)
                {
                    StatByYear statByYearRoutine = new StatByYear();
                    statByYearRoutine.Year = j;
                    statByYearRoutine.MWQMSiteCount = (from c in mwqmSampleList
                                                       where c.SampleDateTime_Local.Year == j
                                                       && c.SampleTypesText.Contains("109")
                                                       select c.MWQMSiteTVItemID).Distinct().Count();
                    statByYearRoutine.MWQMRunCount = (from c in mwqmSampleList
                                                      where c.SampleDateTime_Local.Year == j
                                                      && c.SampleTypesText.Contains("109")
                                                      select c.MWQMRunTVItemID).Distinct().Count();
                    statByYearRoutine.MWQMSampleCount = (from c in mwqmSampleList
                                                         where c.SampleDateTime_Local.Year == j
                                                         && c.SampleTypesText.Contains("109")
                                                         select c).Count();

                    statByYearRoutineSubsectorList.Add(statByYearRoutine);
                }

                webMonitoringRoutineStatsByYearForProvince.MonitoringStatsByYearModelList.Add(new MonitoringStatsByYearModel()
                {
                    TVItemModel = new TVItemModel()
                    {
                        TVItem = tvItemSubsector,
                        TVItemLanguageList = (from c in tvItemLanguageSubsectorList
                                              where c.TVItemID == tvItemSubsector.TVItemID
                                              select c).ToList()

                    },
                    StatByYearList = statByYearRoutineSubsectorList
                });
            }

            // doing Sector ----------------------------------------------
            // -----------------------------------------------------------
            List<TVItem> tvItemSectorList = await GetTVItemAllChildrenListWithTVItemID(tvItemProv, TVTypeEnum.Sector);
            List<TVItemLanguage> tvItemLanguageSectorList = await GetTVItemLanguageAllChildrenListWithTVItemID(tvItemProv, TVTypeEnum.Sector);

            foreach (TVItem tvItemSector in tvItemSectorList)
            {
                List<StatByYear> statByYearSectorRoutineList = new List<StatByYear>();

                List<MonitoringStatsByYearModel> monitoringStatsByYearModelRoutineList = (from c in webMonitoringRoutineStatsByYearForProvince.MonitoringStatsByYearModelList
                                                                                          where c.TVItemModel.TVItem.ParentID == tvItemSector.TVItemID
                                                                                          select c).ToList();

                for (int j = DateTime.Now.Year; j >= 1980; j--)
                {
                    StatByYear statByYearSectorRoutine = new StatByYear();
                    statByYearSectorRoutine.Year = j;
                    statByYearSectorRoutine.MWQMSiteCount = 0;
                    statByYearSectorRoutine.MWQMRunCount = 0;
                    statByYearSectorRoutine.MWQMSampleCount = 0;

                    foreach (MonitoringStatsByYearModel monitoringStatsByYearModel in monitoringStatsByYearModelRoutineList)
                    {
                        StatByYear statByYear = (from c in monitoringStatsByYearModel.StatByYearList
                                                 where c.Year == j
                                                 select c).FirstOrDefault();

                        statByYearSectorRoutine.MWQMSiteCount += statByYear.MWQMSiteCount;
                        statByYearSectorRoutine.MWQMRunCount += statByYear.MWQMRunCount;
                        statByYearSectorRoutine.MWQMSampleCount += statByYear.MWQMSampleCount;

                    }

                    statByYearSectorRoutineList.Add(statByYearSectorRoutine);
                }

                webMonitoringRoutineStatsByYearForProvince.MonitoringStatsByYearModelList.Add(new MonitoringStatsByYearModel()
                {
                    TVItemModel = new TVItemModel()
                    {
                        TVItem = tvItemSector,
                        TVItemLanguageList = (from c in tvItemLanguageSectorList
                                              where c.TVItemID == tvItemSector.TVItemID
                                              select c).ToList()

                    },
                    StatByYearList = statByYearSectorRoutineList
                });
            }

            // doing Area ----------------------------------------------
            // -----------------------------------------------------------
            List<TVItem> tvItemAreaList = await GetTVItemAllChildrenListWithTVItemID(tvItemProv, TVTypeEnum.Area);
            List<TVItemLanguage> tvItemLanguageAreaList = await GetTVItemLanguageAllChildrenListWithTVItemID(tvItemProv, TVTypeEnum.Area);

            foreach (TVItem tvItemArea in tvItemAreaList)
            {
                List<StatByYear> statByYearAreaRoutineList = new List<StatByYear>();

                List<MonitoringStatsByYearModel> monitoringStatsByYearModelRoutineList = (from c in webMonitoringRoutineStatsByYearForProvince.MonitoringStatsByYearModelList
                                                                                          where c.TVItemModel.TVItem.ParentID == tvItemArea.TVItemID
                                                                                          select c).ToList();

                for (int j = DateTime.Now.Year; j >= 1980; j--)
                {
                    StatByYear statByYearAreaRoutine = new StatByYear();
                    statByYearAreaRoutine.Year = j;
                    statByYearAreaRoutine.MWQMSiteCount = 0;
                    statByYearAreaRoutine.MWQMRunCount = 0;
                    statByYearAreaRoutine.MWQMSampleCount = 0;

                    foreach (MonitoringStatsByYearModel monitoringStatsByYearModel in monitoringStatsByYearModelRoutineList)
                    {
                        StatByYear statByYear = (from c in monitoringStatsByYearModel.StatByYearList
                                                 where c.Year == j
                                                 select c).FirstOrDefault();

                        statByYearAreaRoutine.MWQMSiteCount += statByYear.MWQMSiteCount;
                        statByYearAreaRoutine.MWQMRunCount += statByYear.MWQMRunCount;
                        statByYearAreaRoutine.MWQMSampleCount += statByYear.MWQMSampleCount;

                    }

                    statByYearAreaRoutineList.Add(statByYearAreaRoutine);
                }

                webMonitoringRoutineStatsByYearForProvince.MonitoringStatsByYearModelList.Add(new MonitoringStatsByYearModel()
                {
                    TVItemModel = new TVItemModel()
                    {
                        TVItem = tvItemArea,
                        TVItemLanguageList = (from c in tvItemLanguageAreaList
                                              where c.TVItemID == tvItemArea.TVItemID
                                              select c).ToList()

                    },
                    StatByYearList = statByYearAreaRoutineList
                });
            }

            // doing Province ----------------------------------------------
            // -----------------------------------------------------------

            List<StatByYear> statByYearProvinceRoutineList = new List<StatByYear>();

            List<MonitoringStatsByYearModel> monitoringStatsByYearModelProvinceRoutineList = (from c in webMonitoringRoutineStatsByYearForProvince.MonitoringStatsByYearModelList
                                                                                              where c.TVItemModel.TVItem.ParentID == tvItemProv.TVItemID
                                                                                              select c).ToList();

            for (int j = DateTime.Now.Year; j >= 1980; j--)
            {
                StatByYear statByYearProvinceRoutine = new StatByYear();
                statByYearProvinceRoutine.Year = j;
                statByYearProvinceRoutine.MWQMSiteCount = 0;
                statByYearProvinceRoutine.MWQMRunCount = 0;
                statByYearProvinceRoutine.MWQMSampleCount = 0;

                foreach (MonitoringStatsByYearModel monitoringStatsByYearModel in monitoringStatsByYearModelProvinceRoutineList)
                {
                    StatByYear statByYear = (from c in monitoringStatsByYearModel.StatByYearList
                                             where c.Year == j
                                             select c).FirstOrDefault();

                    statByYearProvinceRoutine.MWQMSiteCount += statByYear.MWQMSiteCount;
                    statByYearProvinceRoutine.MWQMRunCount += statByYear.MWQMRunCount;
                    statByYearProvinceRoutine.MWQMSampleCount += statByYear.MWQMSampleCount;

                }

                statByYearProvinceRoutineList.Add(statByYearProvinceRoutine);
            }

            webMonitoringRoutineStatsByYearForProvince.MonitoringStatsByYearModelList.Add(new MonitoringStatsByYearModel()
            {
                TVItemModel = new TVItemModel()
                {
                    TVItem = tvItemProv,
                    TVItemLanguageList = (from c in tvItemLanguageProvList
                                          where c.TVItemID == tvItemProv.TVItemID
                                          select c).ToList()

                },
                StatByYearList = statByYearProvinceRoutineList
            });

            try
            {

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebMonitoringRoutineStatsByYearForProvince>(webMonitoringRoutineStatsByYearForProvince, $"{ WebTypeEnum.WebMonitoringRoutineStatsByYearForProvince }_{tvItemProv.TVItemID}.gz");
                }
                else
                {
                    await DoStore<WebMonitoringRoutineStatsByYearForProvince>(webMonitoringRoutineStatsByYearForProvince, $"{ WebTypeEnum.WebMonitoringRoutineStatsByYearForProvince }_{tvItemProv.TVItemID}.gz");
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
