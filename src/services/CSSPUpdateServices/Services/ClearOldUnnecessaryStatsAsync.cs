namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> ClearOldUnnecessaryStatsAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        // should not be running this function on the original database CSSPDB
        // remove the next line when you are sure
        bool a = true;
        if (a)
        {
            CSSPLogService.AppendError($"This function has been disabled until the database has been completely converted to the new system { DateTime.Now }");
            return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));
        }

        if (!await CSSPLogService.CheckLogin(FunctionName))
        {
            return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));
        }

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

        CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.removing } {TVItemStatList.Count} { CSSPCultureServicesRes.unnecessaryStats } { DateTime.Now }");

        try
        {
            db.RemoveRange(TVItemStatList);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.AppendError($"{ string.Format(CSSPCultureServicesRes.CouldNotRemoveTVItemStatsFromCSSPDBError_, ex.Message) } { DateTime.Now }");

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);


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

        CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.removing } {TVItemStatList.Count} { CSSPCultureServicesRes.unnecessaryStats } { DateTime.Now }");

        try
        {
            db.RemoveRange(TVItemStatList);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.AppendError($"{ string.Format(CSSPCultureServicesRes.CouldNotRemoveTVItemStatsFromCSSPDBError_, ex.Message) } { DateTime.Now }");

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);


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

            CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.removing } {TVItemStatList.Count} { CSSPCultureServicesRes.unnecessaryStats } { DateTime.Now }");

            try
            {
                db.RemoveRange(TVItemStatList);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError($"{ string.Format(CSSPCultureServicesRes.CouldNotRemoveTVItemStatsFromCSSPDBError_, ex.Message) } { DateTime.Now }");

                CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);


                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
            }
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

