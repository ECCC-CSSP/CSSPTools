namespace CSSPDBLocalServices;

public partial class RootLocalService : ControllerBase, IRootLocalService
{
    public async Task<ActionResult<TVItemModel>> ModifyTVTextRootLocalAsync(string TVTextEN, string TVTextFR)
    {
        string parameters = $" --  TVTextEN = { TVTextEN } TVTextFR = { TVTextFR }";

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int TVItemID, string TVTextEN, string TVTextFR) { parameters }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        if (string.IsNullOrWhiteSpace(TVTextEN))
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"));
        }

        if (string.IsNullOrWhiteSpace(TVTextFR))
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        TVItemModel tvItemModelToModify = webRoot.TVItemModel;

        if (tvItemModelToModify == null)
        {
            CSSPLogService.AppendError(CSSPCultureServicesRes.CouldNotFindRoot);
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
        tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        var actionTVItemModelRes = await TVItemLocalService.ModifyTVTextLocalAsync(webRoot.TVItemModel.TVItem, tvItemModelToModify);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModelModified = (TVItemModel)((OkObjectResult)actionTVItemModelRes.Result).Value;

        tvItemModelToModify.TVItem = tvItemModelModified.TVItem;
        tvItemModelToModify.TVItemLanguageList = tvItemModelModified.TVItemLanguageList;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
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

        return await Task.FromResult(Ok(tvItemModelToModify));
    }
}
