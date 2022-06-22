namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> UpdateAllTVItemStatsAsync()
    {
        // Note: Should run the ClearOldUnnecessaryStats command before this one.

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.Reading_, "TVItems") } { DateTime.Now }");
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

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.Reading_, "TVItemStats") } { DateTime.Now }");
        List<TVItemStat> TVItemStatList = (from c in db.TVItemStats
                                           select c).AsNoTracking().ToList();

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.Reading_, "TVItemLinks") } { DateTime.Now }");
        List<TVItemLink> TVItemLinkList = (from c in db.TVItemLinks
                                           select c).AsNoTracking().ToList();

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.Reading_, "Infrastructures") } { DateTime.Now }");
        List<Infrastructure> InfrastructureList = (from c in db.Infrastructures
                                                   select c).AsNoTracking().ToList();

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.Reading_, "PolSourceSites") } { DateTime.Now }");
        List<PolSourceSite> PolSourceSiteList = (from c in db.PolSourceSites
                                                 select c).AsNoTracking().ToList();

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.Reading_, "BoxModels") } { DateTime.Now }");
        List<BoxModel> BoxModelList = (from c in db.BoxModels
                                       select c).AsNoTracking().ToList();

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.Reading_, "UseOfSites") } { DateTime.Now }");
        List<UseOfSite> UseOfSiteList = (from c in db.UseOfSites
                                         select c).AsNoTracking().ToList();

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.Reading_, "TVFiles") } { DateTime.Now }");
        List<TVFile> TVFileList = (from c in db.TVFiles
                                   select c).AsNoTracking().ToList();

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.Reading_, "MWQMSamples") } { DateTime.Now }");
        List<MWQMSample> MWQMSampleList = (from c in db.MWQMSamples
                                           select c).AsNoTracking().ToList();

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.Reading_, "Spills") } { DateTime.Now }");
        List<Spill> SpillList = (from c in db.Spills
                                 select c).AsNoTracking().ToList();

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.Reading_, "VPScenarios") } { DateTime.Now }");
        List<VPScenario> VPScenarioList = (from c in db.VPScenarios
                                           select c).AsNoTracking().ToList();

        List<TVItemStat> TVItemStat2List = new List<TVItemStat>();

        await GetRunSiteSampleStatsForCountryAsync(TVItemStat2List);

        await GetRunSiteSampleStatsUnderProvinceAsync(TVItemList, TVItemProvList, TVItemStat2List);

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.NumberOfTVItemIDAffected_, TVItemForStatList.Count) } { DateTime.Now }");
        CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.RecalculatingTheTVItemStats } { DateTime.Now }");

        int count = 0;
        int total = TVItemForStatList.Count;
        foreach (TVItem tvItem in TVItemForStatList) //.Take(5))
        {
            count += 1;

            if (count % 100 == 0)
            {
                CSSPLogService.AppendLog($"doing ... {count}/{total} - {DateTime.Now}");
            }

            List<TVTypeEnum> SubTVTypeList = GetSubTVTypeForTVItemStatAsync(tvItem.TVType);

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
                    Console.WriteLine($"Done {count}/{total} {tvItem.TVType} - {tvSubType} in {ts.TotalSeconds} seconds count = {ChildCount} { DateTime.Now }");
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
            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.SavingInCSSPDBManageDatabase }  { DateTime.Now }");

            db.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.ErrorWhileSavingAllTVItemStatsChanges_, ex.Message) } { DateTime.Now }");

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

