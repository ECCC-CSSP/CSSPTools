namespace CSSPDBLocalServices;

public partial class ProvinceLocalService : ControllerBase, IProvinceLocalService
{
    public async Task<ActionResult<TVItemModel>> AddProvinceLocalAsync(int ParentTVItemID)
    {
        string parameters = $" --  ParentTVItemID = { ParentTVItemID }";

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID) { parameters }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        if (ParentTVItemID == 0)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVItemID"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

        TVItemModel tvItemModelParent = webCountry.TVItemModel;

        await TVItemLocalService.AddTVItemParentLocalAsync(webCountry.TVItemModelParentList.OrderBy(c => c.TVItem.TVLevel).ToList());

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModelNew = new TVItemModel();

        List<TVItemModel> tvItemModelProvinceList = webCountry.TVItemModelProvinceList;

        string TVTextEN = await HelperLocalService.GetUniqueTVTextAsync(tvItemModelProvinceList, LanguageEnum.en, "New Province");
        string TVTextFR = await HelperLocalService.GetUniqueTVTextAsync(tvItemModelProvinceList, LanguageEnum.fr, "Nouvelle Province");

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemModelParent.TVItem, TVTypeEnum.Province, TVTextEN, TVTextFR);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        tvItemModelNew = tvItemModel;

        List<MapInfoModel> mapInfoModelList = new List<MapInfoModel>();

        foreach (TVItemModel tvItemModelForMapInfo in tvItemModelProvinceList)
        {
            mapInfoModelList.AddRange(tvItemModelForMapInfo.MapInfoModelList);
        }

        var actionMapInfoModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemModelParent.TVItem, tvItemModelNew.TVItem, TVTypeEnum.Province, MapInfoDrawTypeEnum.Point, new List<Coord>());

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        MapInfoModel mapInfoModelPoint = (MapInfoModel)((OkObjectResult)actionMapInfoModelPoint.Result).Value;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        tvItemModelNew.MapInfoModelList.Add(mapInfoModelPoint);

        var actionMapInfoModelPolygon = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemModelParent.TVItem, tvItemModelNew.TVItem, TVTypeEnum.Province, MapInfoDrawTypeEnum.Polygon, new List<Coord>());

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        MapInfoModel mapInfoModelPolygon = (MapInfoModel)((OkObjectResult)actionMapInfoModelPolygon.Result).Value;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        tvItemModelNew.MapInfoModelList.Add(mapInfoModelPolygon);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
            new ToRecreate() { WebType = WebTypeEnum.WebAllProvinces, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebProvince, TVItemID = tvItemModelNew.TVItem.TVItemID },
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

        return await Task.FromResult(Ok(tvItemModelNew));
    }
}
