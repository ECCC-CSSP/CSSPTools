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
        private async Task<ActionResult<bool>> DoCreateWebMonitoringOtherStatsByYearForProvinceGzFile(int ProvinceTVItemID)
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

            WebMonitoringOtherStatsByYearForProvince webMonitoringOtherStatsByYearForProvince = new WebMonitoringOtherStatsByYearForProvince();

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

                List<MonitoringStatByYear> monitoringStatByYearOtherSubsectorList = new List<MonitoringStatByYear>();

                for (int j = DateTime.Now.Year; j >= 1980; j--)
                {
                    MonitoringStatByYear monitoringStatByYearOther = new MonitoringStatByYear();
                    monitoringStatByYearOther.Year = j;
                    monitoringStatByYearOther.MWQMSiteCount = (from c in mwqmSampleList
                                                     where c.SampleDateTime_Local.Year == j
                                                     && !c.SampleTypesText.Contains("109")
                                                     select c.MWQMSiteTVItemID).Distinct().Count();
                    monitoringStatByYearOther.MWQMRunCount = (from c in mwqmSampleList
                                                    where c.SampleDateTime_Local.Year == j
                                                    && !c.SampleTypesText.Contains("109")
                                                    select c.MWQMRunTVItemID).Distinct().Count();
                    monitoringStatByYearOther.MWQMSampleCount = (from c in mwqmSampleList
                                                       where c.SampleDateTime_Local.Year == j
                                                       && !c.SampleTypesText.Contains("109")
                                                       select c).Count();

                    monitoringStatByYearOtherSubsectorList.Add(monitoringStatByYearOther);
                }

                webMonitoringOtherStatsByYearForProvince.MonitoringStatsByYearModelList.Add(new MonitoringStatsByYearModel()
                {
                    TVItemModel = new TVItemModel()
                    {
                        TVItem = tvItemSubsector,
                        TVItemLanguageList = (from c in tvItemLanguageSubsectorList
                                              where c.TVItemID == tvItemSubsector.TVItemID
                                              select c).ToList()

                    },
                    MonitoringStatByYearList = monitoringStatByYearOtherSubsectorList
                });
            }

            // doing Sector ----------------------------------------------
            // -----------------------------------------------------------
            List<TVItem> tvItemSectorList = await GetTVItemAllChildrenListWithTVItemID(tvItemProv, TVTypeEnum.Sector);
            List<TVItemLanguage> tvItemLanguageSectorList = await GetTVItemLanguageAllChildrenListWithTVItemID(tvItemProv, TVTypeEnum.Sector);

            foreach (TVItem tvItemSector in tvItemSectorList)
            {
                List<MonitoringStatByYear> statByYearSectorOtherList = new List<MonitoringStatByYear>();

                List<MonitoringStatsByYearModel> monitoringStatsByYearModelOtherList = (from c in webMonitoringOtherStatsByYearForProvince.MonitoringStatsByYearModelList
                                                                                        where c.TVItemModel.TVItem.ParentID == tvItemSector.TVItemID
                                                                                        select c).ToList();

                for (int j = DateTime.Now.Year; j >= 1980; j--)
                {
                    MonitoringStatByYear statByYearSectorOther = new MonitoringStatByYear();
                    statByYearSectorOther.Year = j;
                    statByYearSectorOther.MWQMSiteCount = 0;
                    statByYearSectorOther.MWQMRunCount = 0;
                    statByYearSectorOther.MWQMSampleCount = 0;

                    foreach (MonitoringStatsByYearModel monitoringStatsByYearModel in monitoringStatsByYearModelOtherList)
                    {
                        MonitoringStatByYear statByYear = (from c in monitoringStatsByYearModel.MonitoringStatByYearList
                                                 where c.Year == j
                                                 select c).FirstOrDefault();

                        statByYearSectorOther.MWQMSiteCount += statByYear.MWQMSiteCount;
                        statByYearSectorOther.MWQMRunCount += statByYear.MWQMRunCount;
                        statByYearSectorOther.MWQMSampleCount += statByYear.MWQMSampleCount;

                    }

                    statByYearSectorOtherList.Add(statByYearSectorOther);
                }

                webMonitoringOtherStatsByYearForProvince.MonitoringStatsByYearModelList.Add(new MonitoringStatsByYearModel()
                {
                    TVItemModel = new TVItemModel()
                    {
                        TVItem = tvItemSector,
                        TVItemLanguageList = (from c in tvItemLanguageSectorList
                                              where c.TVItemID == tvItemSector.TVItemID
                                              select c).ToList()

                    },
                    MonitoringStatByYearList = statByYearSectorOtherList
                });
            }

            // doing Area ----------------------------------------------
            // -----------------------------------------------------------
            List<TVItem> tvItemAreaList = await GetTVItemAllChildrenListWithTVItemID(tvItemProv, TVTypeEnum.Area);
            List<TVItemLanguage> tvItemLanguageAreaList = await GetTVItemLanguageAllChildrenListWithTVItemID(tvItemProv, TVTypeEnum.Area);

            foreach (TVItem tvItemArea in tvItemAreaList)
            {
                List<MonitoringStatByYear> statByYearAreaOtherList = new List<MonitoringStatByYear>();

                List<MonitoringStatsByYearModel> monitoringStatsByYearModelOtherList = (from c in webMonitoringOtherStatsByYearForProvince.MonitoringStatsByYearModelList
                                                                                        where c.TVItemModel.TVItem.ParentID == tvItemArea.TVItemID
                                                                                        select c).ToList();

                for (int j = DateTime.Now.Year; j >= 1980; j--)
                {
                    MonitoringStatByYear statByYearAreaOther = new MonitoringStatByYear();
                    statByYearAreaOther.Year = j;
                    statByYearAreaOther.MWQMSiteCount = 0;
                    statByYearAreaOther.MWQMRunCount = 0;
                    statByYearAreaOther.MWQMSampleCount = 0;

                    foreach (MonitoringStatsByYearModel monitoringStatsByYearModel in monitoringStatsByYearModelOtherList)
                    {
                        MonitoringStatByYear statByYear = (from c in monitoringStatsByYearModel.MonitoringStatByYearList
                                                 where c.Year == j
                                                 select c).FirstOrDefault();

                        statByYearAreaOther.MWQMSiteCount += statByYear.MWQMSiteCount;
                        statByYearAreaOther.MWQMRunCount += statByYear.MWQMRunCount;
                        statByYearAreaOther.MWQMSampleCount += statByYear.MWQMSampleCount;

                    }

                    statByYearAreaOtherList.Add(statByYearAreaOther);
                }

                webMonitoringOtherStatsByYearForProvince.MonitoringStatsByYearModelList.Add(new MonitoringStatsByYearModel()
                {
                    TVItemModel = new TVItemModel()
                    {
                        TVItem = tvItemArea,
                        TVItemLanguageList = (from c in tvItemLanguageAreaList
                                              where c.TVItemID == tvItemArea.TVItemID
                                              select c).ToList()

                    },
                    MonitoringStatByYearList = statByYearAreaOtherList
                });
            }

            // doing Province ----------------------------------------------
            // -----------------------------------------------------------

            List<MonitoringStatByYear> statByYearProvinceOtherList = new List<MonitoringStatByYear>();

            List<MonitoringStatsByYearModel> monitoringStatsByYearModelProvinceOtherList = (from c in webMonitoringOtherStatsByYearForProvince.MonitoringStatsByYearModelList
                                                                                            where c.TVItemModel.TVItem.ParentID == tvItemProv.TVItemID
                                                                                            select c).ToList();

            for (int j = DateTime.Now.Year; j >= 1980; j--)
            {
                MonitoringStatByYear statByYearProvinceOther = new MonitoringStatByYear();
                statByYearProvinceOther.Year = j;
                statByYearProvinceOther.MWQMSiteCount = 0;
                statByYearProvinceOther.MWQMRunCount = 0;
                statByYearProvinceOther.MWQMSampleCount = 0;

                foreach (MonitoringStatsByYearModel monitoringStatsByYearModel in monitoringStatsByYearModelProvinceOtherList)
                {
                    MonitoringStatByYear statByYear = (from c in monitoringStatsByYearModel.MonitoringStatByYearList
                                             where c.Year == j
                                             select c).FirstOrDefault();

                    statByYearProvinceOther.MWQMSiteCount += statByYear.MWQMSiteCount;
                    statByYearProvinceOther.MWQMRunCount += statByYear.MWQMRunCount;
                    statByYearProvinceOther.MWQMSampleCount += statByYear.MWQMSampleCount;

                }

                statByYearProvinceOtherList.Add(statByYearProvinceOther);
            }

            webMonitoringOtherStatsByYearForProvince.MonitoringStatsByYearModelList.Add(new MonitoringStatsByYearModel()
            {
                TVItemModel = new TVItemModel()
                {
                    TVItem = tvItemProv,
                    TVItemLanguageList = (from c in tvItemLanguageProvList
                                          where c.TVItemID == tvItemProv.TVItemID
                                          select c).ToList()

                },
                MonitoringStatByYearList = statByYearProvinceOtherList
            });

            try
            {
                if (dbLocal != null)
                {
                    await DoStoreLocal<WebMonitoringOtherStatsByYearForProvince>(webMonitoringOtherStatsByYearForProvince, $"{ WebTypeEnum.WebMonitoringOtherStatsByYearForProvince }_{tvItemProv.TVItemID}.gz");
                }
                else
                {
                    await DoStore<WebMonitoringOtherStatsByYearForProvince>(webMonitoringOtherStatsByYearForProvince, $"{ WebTypeEnum.WebMonitoringOtherStatsByYearForProvince }_{tvItemProv.TVItemID}.gz");
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
