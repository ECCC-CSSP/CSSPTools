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
            LogAppend(sbLog, $"Starting DoClearOldUnnecessaryStats ...");
            LogAppend(sbLog, $"Reading TVItemStats for deleting unnecessary stats ...");

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

            LogAppend(sbLog, $"Cleaning CSSPDB of old TVItemStats --- removing {TVItemStatList.Count} unnecessary stats");

            try
            {
                db.RemoveRange(TVItemStatList);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorAppend(sbError, $"Could not remove TVItemStats from CSSPDB. Ex: {ex.Message}");

                await StoreInCommandLog(sbLog, sbError, "ClearOldUnnecessaryStats");

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

            LogAppend(sbLog, $"Cleaning CSSPDB of old TVItemStats --- removing {TVItemStatList.Count} unnecessary stats");

            try
            {
                db.RemoveRange(TVItemStatList);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorAppend(sbError, $"Could not remove TVItemStats from CSSPDB. Ex: {ex.Message}");

                await StoreInCommandLog(sbLog, sbError, "ClearOldUnnecessaryStats");

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

                LogAppend(sbLog, $"Cleaning CSSPDB of old TVItemStats --- removing {TVItemStatList.Count} unnecessary stats");

                try
                {
                    db.RemoveRange(TVItemStatList);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ErrorAppend(sbError, $"Could not remove TVItemStats from CSSPDB. Ex: {ex.Message}");

                    await StoreInCommandLog(sbLog, sbError, "ClearOldUnnecessaryStats");

                    return await Task.FromResult(false);
                }
            }

            LogAppend(sbLog, $"End DoClearOldUnnecessaryStats ...");
            LogAppend(sbLog, $"Success ...");

            await StoreInCommandLog(sbLog, sbError, "ClearOldUnnecessaryStats");

            return await Task.FromResult(true);
        }
    }
}
