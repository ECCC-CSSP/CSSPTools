/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using ManageServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        private async Task<bool> DoClearOldUnnecessaryStats()
        {
            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.Starting } DoClearOldUnnecessaryStats ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.ReadingTVItemStatsForDeletingUnnecessaryStats } ...");

            List<TVItemStat> TVItemStatList = (from c in db.TVItemStats
                                               where !(c.TVType == TVTypeEnum.Root
                                               || c.TVType == TVTypeEnum.Country
                                               || c.TVType == TVTypeEnum.File
                                               || c.TVType == TVTypeEnum.TotalFile
                                               || c.TVType == TVTypeEnum.Infrastructure
                                               || c.TVType == TVTypeEnum.MikeScenario
                                               || c.TVType == TVTypeEnum.MWQMRun
                                               || c.TVType == TVTypeEnum.MWQMSite
                                               || c.TVType == TVTypeEnum.PolSourceSite
                                               || c.TVType == TVTypeEnum.Province
                                               || c.TVType == TVTypeEnum.Sector
                                               || c.TVType == TVTypeEnum.Subsector
                                               || c.TVType == TVTypeEnum.MWQMSiteSample
                                               || c.TVType == TVTypeEnum.WasteWaterTreatmentPlant
                                               || c.TVType == TVTypeEnum.LiftStation
                                               || c.TVType == TVTypeEnum.BoxModel
                                               || c.TVType == TVTypeEnum.VisualPlumesScenario)
                                               select c).ToList();

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.ReadingTVItemStatsForDeletingUnnecessaryStats } --- { CSSPCultureUpdateRes.removing } [{TVItemStatList.Count}] { CSSPCultureUpdateRes.unnecessaryStats }");

            try
            {
                db.RemoveRange(TVItemStatList);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError($"{ string.Format(CSSPCultureUpdateRes.CouldNotRemoveTVItemStatsFromCSSPDBError_, ex.Message) }");

                await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.ClearOldUnnecessaryStats);

                return await Task.FromResult(false);
            }

            TVItemStatList = (from t in db.TVItems
                              from c in db.TVItemStats
                              where t.TVItemID == c.TVItemID
                              && !(t.TVType == TVTypeEnum.Root
                              || t.TVType == TVTypeEnum.Country
                              || t.TVType == TVTypeEnum.Province
                              || t.TVType == TVTypeEnum.Area
                              || t.TVType == TVTypeEnum.Sector
                              || t.TVType == TVTypeEnum.Subsector
                              || t.TVType == TVTypeEnum.Municipality)
                              select c).ToList();

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.CleaningCSSPDBOfOldTVItemStats } --- { CSSPCultureUpdateRes.removing } {TVItemStatList.Count} { CSSPCultureUpdateRes.unnecessaryStats }");

            try
            {
                db.RemoveRange(TVItemStatList);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError($"{ string.Format(CSSPCultureUpdateRes.CouldNotRemoveTVItemStatsFromCSSPDBError_, ex.Message) }");

                await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.ClearOldUnnecessaryStats);

                return await Task.FromResult(false);
            }

            List<TVTypeEnum> tvTypeList = new List<TVTypeEnum>() { TVTypeEnum.Area, TVTypeEnum.Sector, TVTypeEnum.Subsector };

            foreach (TVTypeEnum tvTypeToDel in tvTypeList)
            {
                TVItemStatList = (from t in db.TVItems
                                  from c in db.TVItemStats
                                  where t.TVItemID == c.TVItemID
                                  && t.TVType == tvTypeToDel
                                  && (c.TVType == TVTypeEnum.Infrastructure
                                  || c.TVType == TVTypeEnum.Municipality
                                  || c.TVType == TVTypeEnum.WasteWaterTreatmentPlant
                                  || c.TVType == TVTypeEnum.LiftStation
                                  || c.TVType == TVTypeEnum.BoxModel
                                  || c.TVType == TVTypeEnum.VisualPlumesScenario
                                  || c.TVType == TVTypeEnum.MikeScenario)
                                  select c).ToList();

                CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.CleaningCSSPDBOfOldTVItemStats } --- { CSSPCultureUpdateRes.removing } {TVItemStatList.Count} { CSSPCultureUpdateRes.unnecessaryStats }");

                try
                {
                    db.RemoveRange(TVItemStatList);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    CSSPLogService.AppendError($"{ string.Format(CSSPCultureUpdateRes.CouldNotRemoveTVItemStatsFromCSSPDBError_, ex.Message) }");

                    await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.ClearOldUnnecessaryStats);

                    return await Task.FromResult(false);
                }
            }

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.End } DoClearOldUnnecessaryStats ...");

            await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.ClearOldUnnecessaryStats);

            return await Task.FromResult(true);
        }
    }
}
