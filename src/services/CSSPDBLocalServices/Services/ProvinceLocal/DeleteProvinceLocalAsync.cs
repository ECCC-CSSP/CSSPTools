namespace CSSPDBLocalServices;

public partial class ProvinceLocalService : ControllerBase, IProvinceLocalService
{
    public async Task<ActionResult<TVItemModel>> DeleteProvinceLocalAsync(int ParentTVItemID, int TVItemID)
    {
        string parameters = $" -- ParentTVItemID = { ParentTVItemID } TVItemID = { TVItemID }";

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID, int TVItemID) { parameters }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        if (ParentTVItemID == 0)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVItemID"));
        }

        if (TVItemID == 0)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModelToDelete = (from c in webCountry.TVItemModelProvinceList
                                           where c.TVItem.TVItemID == TVItemID
                                           select c).FirstOrDefault();

        if (tvItemModelToDelete == null)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemModel", "TVItemID", $"{ TVItemID }"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        await HelperLocalService.CheckIfChildExistAsync(webCountry.TVItemModel.TVItem, tvItemModelToDelete.TVItem);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        // deleting MapInfo and MapInfoPoints
        foreach (MapInfoModel mapInfoModel in tvItemModelToDelete.MapInfoModelList)
        {
            var actionMapInfoModelRes = await MapInfoLocalService.DeleteMapInfoLocalAsync(webCountry.TVItemModel.TVItem, tvItemModelToDelete.TVItem, TVTypeEnum.Province, mapInfoModel.MapInfo.MapInfoDrawType);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            MapInfoModel mapInfoModelDeleted = (MapInfoModel)((OkObjectResult)actionMapInfoModelRes.Result).Value;

            mapInfoModel.MapInfo = mapInfoModelDeleted.MapInfo;
            mapInfoModel.MapInfoPointList = mapInfoModelDeleted.MapInfoPointList;
        }

        // deleting TVItem
        var actionTVItemModelRes = await TVItemLocalService.DeleteTVItemLocalAsync(webCountry.TVItemModel.TVItem, tvItemModelToDelete);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModelDeleted = (TVItemModel)((OkObjectResult)actionTVItemModelRes.Result).Value;

        tvItemModelToDelete.TVItem = tvItemModelDeleted.TVItem;
        tvItemModelToDelete.TVItemLanguageList = tvItemModelDeleted.TVItemLanguageList;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
            new ToRecreate() { WebType = WebTypeEnum.WebAllProvinces, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebProvince, TVItemID = tvItemModelToDelete.TVItem.TVItemID },
        };

        await CSSPCreateGzFileService.SetLocal(true);

        foreach (ToRecreate toRecreate in ToRecreateList)
        {
            var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(toRecreate.WebType, toRecreate.TVItemID);
            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
            {
                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(tvItemModelToDelete));
    }
}
