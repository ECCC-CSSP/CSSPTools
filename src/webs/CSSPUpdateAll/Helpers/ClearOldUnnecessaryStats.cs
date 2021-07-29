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

namespace CSSPUpdateAll
{
    public partial class Startup
    {
        private async Task<bool> ClearOldUnnecessaryStats()
        {
            Console.WriteLine($"Reading TVItemStats for deleting unnecessary stats ...");
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

            Console.WriteLine($"Cleaning CSSPDB of old TVItemStats --- removing {TVItemStatList.Count} unnecessary stats");

            try
            {
                db.RemoveRange(TVItemStatList);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not remove TVItemStats from CSSPDB. Ex: {ex.Message}");
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

            Console.WriteLine($"Cleaning CSSPDB of old TVItemStats --- removing {TVItemStatList.Count} unnecessary stats");

            try
            {
                db.RemoveRange(TVItemStatList);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not remove TVItemStats from CSSPDB. Ex: {ex.Message}");
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

                Console.WriteLine($"Cleaning CSSPDB of old TVItemStats --- removing {TVItemStatList.Count} unnecessary stats");

                try
                {
                    db.RemoveRange(TVItemStatList);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not remove TVItemStats from CSSPDB. Ex: {ex.Message}");
                    return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }
    }
}
