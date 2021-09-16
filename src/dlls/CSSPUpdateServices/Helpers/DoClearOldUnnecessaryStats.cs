/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        private async Task<ActionResult<bool>> DoClearOldUnnecessaryStats()
        {
            CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.ReadingTVItemStatsForDeletingUnnecessaryStats } { DateTime.Now }");

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

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.removing } [{TVItemStatList.Count}] { CSSPCultureUpdateRes.unnecessaryStats } { DateTime.Now }");

            try
            {
                db.RemoveRange(TVItemStatList);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError($"{ string.Format(CSSPCultureUpdateRes.CouldNotRemoveTVItemStatsFromCSSPDBError_, ex.Message) } { DateTime.Now }");

                CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
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

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.removing } {TVItemStatList.Count} { CSSPCultureUpdateRes.unnecessaryStats } { DateTime.Now }");

            try
            {
                db.RemoveRange(TVItemStatList);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError($"{ string.Format(CSSPCultureUpdateRes.CouldNotRemoveTVItemStatsFromCSSPDBError_, ex.Message) } { DateTime.Now }");

                CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
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

                CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.removing } {TVItemStatList.Count} { CSSPCultureUpdateRes.unnecessaryStats } { DateTime.Now }");

                try
                {
                    db.RemoveRange(TVItemStatList);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    CSSPLogService.AppendError($"{ string.Format(CSSPCultureUpdateRes.CouldNotRemoveTVItemStatsFromCSSPDBError_, ex.Message) } { DateTime.Now }");

                    CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                    await CSSPLogService.Save();

                    return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                }
            }

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(Ok(true));
        }
    }
}
