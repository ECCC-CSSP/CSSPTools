namespace CSSPDBLocalServices;

public partial class ProvinceLocalService : ControllerBase, IProvinceLocalService
{
    public async Task<ActionResult<TVItemModel>> ModifyTVTextProvinceLocalAsync(int ParentTVItemID, int TVItemID, string TVTextEN, string TVTextFR)
    {
        string parameters = $" --  ParentTVItemID = { ParentTVItemID } TVItemID = { TVItemID } TVTextEN = { TVTextEN } TVTextFR = { TVTextFR }";

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID, int TVItemID, string TVTextEN, string TVTextFR) { parameters }";
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

        if (string.IsNullOrWhiteSpace(TVTextEN))
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"));
        }
        else
        {
            if (TVTextEN.Length > 200)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TVTextEN", 200));
            }
        }

        if (string.IsNullOrWhiteSpace(TVTextFR))
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"));
        }
        else
        {
            if (TVTextFR.Length > 200)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TVTextFR", 200));
            }
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModelToModify = (from c in webCountry.TVItemModelProvinceList
                                           where c.TVItem.TVItemID == TVItemID
                                           select c).FirstOrDefault();

        if (tvItemModelToModify == null)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemModel", "TVItemID", $"{ TVItemID }"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        await HelperLocalService.CheckIfSiblingsExistWithSameTVTextAsync(webCountry.TVItemModel.TVItem, TVTypeEnum.Province, TVTextEN, TVTextFR, TVItemID);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
        tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        var actionTVItemModelRes = await TVItemLocalService.ModifyTVTextLocalAsync(webCountry.TVItemModel.TVItem, tvItemModelToModify);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModelModified = (TVItemModel)((OkObjectResult)actionTVItemModelRes.Result).Value;

        tvItemModelToModify.TVItem = tvItemModelModified.TVItem;
        tvItemModelToModify.TVItemLanguageList = tvItemModelModified.TVItemLanguageList;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
            new ToRecreate() { WebType = WebTypeEnum.WebAllProvinces, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebProvince, TVItemID = tvItemModelToModify.TVItem.TVItemID },
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
