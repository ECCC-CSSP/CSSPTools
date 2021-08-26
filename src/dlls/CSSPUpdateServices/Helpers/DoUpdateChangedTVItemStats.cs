using CSSPDBModels;
using CSSPDBServices;
using CSSPEnums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using CSSPWebModels;
using System.Text.Json;
using System.IO;
using CSSPCultureServices.Resources;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        public async Task<bool> DoUpdateChangedTVItemStats()
        {
            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.Starting } DoUpdateChangedTVItemStats ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.UpdatingAllTVItemStatsTimeStarted_, DateTime.Now) }");

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.CleaningCSSPDBOfOldTVItemStats }");

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "TVItems") } ...");

            List<TVItem> TVItemList = (from c in db.TVItems
                                       select c).AsNoTracking().ToList();

            List<TVItem> TVItemForStatList = (from c in TVItemList
                                              where c.TVType == TVTypeEnum.Root
                                              || c.TVType == TVTypeEnum.Country
                                              || c.TVType == TVTypeEnum.Province
                                              || c.TVType == TVTypeEnum.Area
                                              || c.TVType == TVTypeEnum.Sector
                                              || c.TVType == TVTypeEnum.Subsector
                                              || c.TVType == TVTypeEnum.Municipality
                                              select c).ToList();

            List<TVItem> TVItemProvList = (from c in TVItemForStatList
                                           where c.TVType == TVTypeEnum.Province
                                           select c).ToList();

            if (!await ClearOldUnnecessaryStats())
            {
                CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.ErrorInClearOldUnnecessaryStatsFrom_, "DoUpdateChangedTVItemStats") }");

                await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.UpdateChangedTVItemStats);

                return await Task.FromResult(false);
            }

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "TVItems") } ...");
            TVItemList = (from c in db.TVItems
                          select c).AsNoTracking().ToList();

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "TVItemStats") } ...");
            List<TVItemStat> TVItemStatList = (from c in db.TVItemStats
                                               select c).AsNoTracking().ToList();

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "TVItemLinks") } ...");
            List<TVItemLink> TVItemLinkList = (from c in db.TVItemLinks
                                               select c).AsNoTracking().ToList();

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "Infrastructures") } ...");
            List<Infrastructure> InfrastructureList = (from c in db.Infrastructures
                                                       select c).AsNoTracking().ToList();

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "PolSourceSites") } ...");
            List<PolSourceSite> PolSourceSiteList = (from c in db.PolSourceSites
                                                     select c).AsNoTracking().ToList();

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "BoxModels") } ...");
            List<BoxModel> BoxModelList = (from c in db.BoxModels
                                           select c).AsNoTracking().ToList();

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "UseOfSites") } ...");
            List<UseOfSite> UseOfSiteList = (from c in db.UseOfSites
                                             select c).AsNoTracking().ToList();

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "TVFiles") } ...");
            List<TVFile> TVFileList = (from c in db.TVFiles
                                       select c).AsNoTracking().ToList();

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "MWQMSamples") } ...");
            List<MWQMSample> MWQMSampleList = (from c in db.MWQMSamples
                                               select c).AsNoTracking().ToList();

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "Spills") } ...");
            List<Spill> SpillList = (from c in db.Spills
                                     select c).AsNoTracking().ToList();

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.Reading_, "VPScenarios") } ...");
            List<VPScenario> VPScenarioList = (from c in db.VPScenarios
                                               select c).AsNoTracking().ToList();

            List<TVItemStat> TVItemStat2List = new List<TVItemStat>();

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.CollectingStatsFor_, "Country MWQMRun, MWQMSite, MWQMSiteSample") } ...");
            await GetRunSiteSampleStatsForCountry(TVItemStat2List);

            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.CollectingStatsUnder_, "Province MWQMRun, MWQMSite, MWQMSiteSample") } ...");
            await GetRunSiteSampleStatsUnderProvince(TVItemList, TVItemProvList, TVItemStat2List);

            DirectoryInfo di = new DirectoryInfo($"{azure_csspjson_backup}");

            FileInfo fiJSONLatest = (from c in di.GetFiles()
                                     orderby c.LastWriteTimeUtc descending
                                     select c).FirstOrDefault();

            if (fiJSONLatest == null)
            {
                CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.CouldNotFindAnyFileUnder_, di.FullName) }");

                CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.ErrorInClearOldUnnecessaryStatsFrom_, "DoUpdateChangedTVItemStats") }");

                await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.UpdateChangedTVItemStats);

                return await Task.FromResult(false);
            }

            List<TVItem> TVItemForChangedStatList = new List<TVItem>();

            foreach (TVItem tvItem in TVItemForStatList)
            {
                if (tvItem.LastUpdateDate_UTC >= fiJSONLatest.LastWriteTimeUtc)
                {
                    if (!TVItemForChangedStatList.Where(c => c.TVItemID == tvItem.TVItemID).Any())
                    {
                        TVItemForChangedStatList.Add(tvItem);

                        List<int> TVItemIDParentList = tvItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

                        foreach (int TVItemIDParent in TVItemIDParentList)
                        {
                            if (!TVItemForChangedStatList.Where(c => c.TVItemID == TVItemIDParent).Any())
                            {
                                TVItem tvItemParent = TVItemForStatList.Where(c => c.TVItemID == TVItemIDParent).FirstOrDefault();

                                if (tvItemParent != null)
                                {
                                    TVItemForChangedStatList.Add(tvItemParent);
                                }
                            }
                        }
                    }
                }
            }

            List<int> municipalityTVItemIDList = await GetTVItemIDListMunicipalityOfChangedBoxModel(fiJSONLatest.LastWriteTimeUtc);


            int count = 0;
            int total = TVItemForChangedStatList.Count;
            foreach (TVItem tvItem in TVItemForChangedStatList)
            {
                count += 1;

                List<TVTypeEnum> SubTVTypeList = GetSubTVTypeForTVItemStat(tvItem.TVType);

                foreach (TVTypeEnum tvSubType in SubTVTypeList)
                {
                    DateTime StartTime = DateTime.Now;

                    int ChildCount = -1;
                    switch (tvSubType)
                    {
                        case TVTypeEnum.Area:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == tvSubType)
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.BoxModel:
                            {
                                if (tvItem.TVType == TVTypeEnum.Infrastructure)
                                {
                                    ChildCount = (from b in BoxModelList
                                                  where b.InfrastructureTVItemID == tvItem.TVItemID
                                                  select b).Count();
                                }
                                else
                                {
                                    ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Infrastructure)
                                                  from b in BoxModelList
                                                  where c.TVItemID == b.InfrastructureTVItemID
                                                  && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                                  select b).Count();
                                }
                            }
                            break;
                        case TVTypeEnum.Country:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Country)
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.File:
                            {
                                int TVLevelFile = tvItem.TVLevel + 1;
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.File)
                                              where c.TVLevel == TVLevelFile
                                              && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.Infrastructure:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Infrastructure)
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.LiftStation:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Infrastructure)
                                              from inf in InfrastructureList.Where(c => c.InfrastructureType == InfrastructureTypeEnum.LiftStation)
                                              where c.TVItemID == inf.InfrastructureTVItemID
                                              && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select inf).Count();
                            }
                            break;
                        case TVTypeEnum.MikeScenario:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.MikeScenario)
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.MikeSource:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.MikeSource)
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.Municipality:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Municipality)
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.PolSourceSite:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.PolSourceSite)
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.Province:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Province)
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.Sector:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Sector)
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              && c.TVType == TVTypeEnum.Sector
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.Subsector:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Subsector)
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.TotalFile:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.File)
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select c).Count();
                            }
                            break;
                        case TVTypeEnum.VisualPlumesScenario:
                            {
                                if (tvItem.TVType == TVTypeEnum.Infrastructure)
                                {
                                    ChildCount = (from v in VPScenarioList
                                                  where v.InfrastructureTVItemID == tvItem.TVItemID
                                                  select v).Count();
                                }
                                else
                                {
                                    ChildCount = (from c in TVItemList.Where(c => c.TVType == tvItem.TVType)
                                                  from v in VPScenarioList
                                                  where c.TVItemID == v.InfrastructureTVItemID
                                                  && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                                  select v).Count();
                                }
                            }
                            break;
                        case TVTypeEnum.WasteWaterTreatmentPlant:
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Infrastructure)
                                              from inf in InfrastructureList.Where(c => c.InfrastructureType == InfrastructureTypeEnum.WWTP)
                                              where c.TVItemID == inf.InfrastructureTVItemID
                                              && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              select inf).Count();
                            }
                            break;
                        default:
                            break;
                    }

                    TVItemStat2List.Add(new TVItemStat()
                    {
                        TVItemID = tvItem.TVItemID,
                        DBCommand = DBCommandEnum.Original,
                        TVType = tvSubType,
                        ChildCount = ChildCount,
                        LastUpdateDate_UTC = DateTime.Now,
                        LastUpdateContactTVItemID = 2
                    });

                    DateTime EndTime = DateTime.Now;

                    TimeSpan ts = new TimeSpan(EndTime.Ticks - StartTime.Ticks);

                    if (count % 1000 == 0)
                    {
                        Console.WriteLine($"Done {count}/{total} {tvItem.TVType} - {tvSubType} in {ts.TotalSeconds} seconds count = {ChildCount} ...");
                    }
                }
            }

            List<TVItemStat> TVItemStatDBList = (from c in db.TVItemStats
                                                 select c).ToList();

            foreach (TVItemStat tvItemStat in TVItemStat2List)
            {
                TVItemStat tvItemStatDB = TVItemStatDBList.Where(c => c.TVItemID == tvItemStat.TVItemID && c.TVType == tvItemStat.TVType).FirstOrDefault();

                if (tvItemStatDB == null)
                {
                    db.TVItemStats.Add(tvItemStat);
                }
                else
                {
                    if (tvItemStatDB.ChildCount != tvItemStat.ChildCount)
                    {
                        tvItemStatDB.ChildCount = tvItemStat.ChildCount;
                    }
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.ErrorWhileSavingAllTVItemStatsChanges_, ex.Message) }");
            }

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.End } DoUpdateChangedTVItemStats ...");

            await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.UpdateAllTVItemStats);

            return await Task.FromResult(true);
        }
    }
}
