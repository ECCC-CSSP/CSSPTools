namespace CSSPDBLocalServices;

public partial class ClassificationLocalService : ControllerBase, IClassificationLocalService
{
    public async Task<ActionResult<ClassificationModel>> DeleteClassificationLocalAsync(int SubsectorTVItemID, int ClassificationTVItemID)
    {
        string parameters = $" -- SubsectorTVItemID = { SubsectorTVItemID }  ClassificationTVItemID = { ClassificationTVItemID } ";

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int SubsectorTVItemID, int ClassificationID) { parameters }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        #region Check Classification
        if (SubsectorTVItemID == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "SubsectorTVItemID"));
        }
        if (ClassificationTVItemID == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "ClassificationTVItemID"));
        }
        #endregion Check Classification

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, SubsectorTVItemID);

        ClassificationModel classificationModel = (from c in webSubsector.ClassificationModelList
                                                   where c.Classification.ClassificationTVItemID == ClassificationTVItemID
                                                   select c).FirstOrDefault();

        if (classificationModel == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ClassificationModel", "ClassificationTVItemID", ClassificationTVItemID.ToString()));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        MapInfoModel mapInfoModelToDelete = (from c in classificationModel.TVItemModel.MapInfoModelList
                                             where c.MapInfo.MapInfoDrawType == MapInfoDrawTypeEnum.Polyline
                                             select c).FirstOrDefault();

        var actionMapInfo = await MapInfoLocalService.DeleteMapInfoLocalAsync(webSubsector.TVItemModel.TVItem, classificationModel.TVItemModel.TVItem, mapInfoModelToDelete.MapInfo.TVType, MapInfoDrawTypeEnum.Polyline);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        MapInfoModel mapInfoModel = (MapInfoModel)((OkObjectResult)actionMapInfo.Result).Value;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocalAsync(webSubsector.TVItemModel.TVItem, classificationModel.TVItemModel);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));


        Classification classification = (from c in dbLocal.Classifications
                                         where c.ClassificationTVItemID == ClassificationTVItemID
                                         select c).FirstOrDefault();

        if (classification == null)
        {
            try
            {
                classificationModel.Classification.DBCommand = DBCommandEnum.Deleted;
                classificationModel.Classification.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                classificationModel.Classification.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.Classifications.Add(classificationModel.Classification);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "Classification", ex.Message));
            }
        }
        else
        {
            try
            {
                classification.DBCommand = DBCommandEnum.Deleted;
                classification.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                classification.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "Classification", ex.Message));
            }

        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        await CSSPCreateGzFileService.SetLocal(true);

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebSubsector, SubsectorTVItemID);
        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
        {
            ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        CSSPLogService.EndFunctionLog(FunctionName);

        ClassificationLocalModel classificationLocalModel = new ClassificationLocalModel()
        {
            TVItemParent = webSubsector.TVItemModel.TVItem,
            TVItemModel = tvItemModel,
            Classification = classification,
        };

        return await Task.FromResult(Ok(classificationLocalModel));
    }
}
