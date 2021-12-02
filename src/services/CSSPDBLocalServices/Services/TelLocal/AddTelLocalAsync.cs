namespace CSSPDBLocalServices;

public partial class TelLocalService : ControllerBase, ITelLocalService
{
    public async Task<ActionResult<Tel>> AddTelLocalAsync(Tel tel)
    {
        string parameters = "";
        if (tel != null)
        {
            parameters = $" --  TelNumber = { tel.TelNumber ?? "--" } " +
                $"TelType = { tel.TelType.ToString() ?? "--" }";
        }

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(Tel tel) { parameters }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        #region Check Tel
        if (tel == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tel"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        if (tel.TelID != 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TelID", "0"));
        }

        if (string.IsNullOrWhiteSpace(tel.TelNumber))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TelNumber"));
        }
        else
        {
            if (tel.TelNumber.Length > 50)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TelNumber", "50"));
            }
        }

        string retStr = enums.EnumTypeOK(typeof(TelTypeEnum), (int?)tel.TelType);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TelType"));
        }
        #endregion Check Tel

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        WebAllTels webAllTels = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllTels>(WebTypeEnum.WebAllTels, 0);

        Tel telJSON = (from c in webAllTels.TelList
                       where c.TelNumber == tel.TelNumber
                       select c).FirstOrDefault();

        if (telJSON != null)
        {
            return await Task.FromResult(Ok(telJSON));
        }

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        await TVItemLocalService.AddTVItemParentLocalAsync(webRoot.TVItemModelParentList.OrderBy(c => c.TVItem.TVLevel).ToList());

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        string TVTextEN = $"{ tel.TelNumber }";
        string TVTextFR = $"{ tel.TelNumber }";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(webRoot.TVItemModel.TVItem, TVTypeEnum.Tel, TVTextEN, TVTextFR);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        int TelIDNew = (from c in dbLocal.Tels
                        where c.TelID < 0
                        orderby c.TelID ascending
                        select c.TelID).FirstOrDefault() - 1;

        tel.DBCommand = DBCommandEnum.Created;
        tel.TelID = TelIDNew;
        tel.TelTVItemID = tvItemModel.TVItem.TVItemID;
        tel.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
        tel.LastUpdateDate_UTC = DateTime.UtcNow;

        dbLocal.Tels.Add(tel);
        try
        {
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Tel", ex.Message));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
            {
                new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
                new ToRecreate() { WebType = WebTypeEnum.WebAllTels, TVItemID = 0 },
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

        return await Task.FromResult(Ok(tel));
    }
}
