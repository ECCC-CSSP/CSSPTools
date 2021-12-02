namespace CSSPDBLocalServices;

public partial class MWQMLookupMPNLocalService : ControllerBase, IMWQMLookupMPNLocalService
{
    public async Task<ActionResult<MWQMLookupMPN>> ModifyMWQMLookupMPNLocalAsync(MWQMLookupMPN mwqmLookupMPN)
    {
        string parameters = $" --  DocKey = { mwqmLookupMPN.MPN_100ml } " +
        $"Tubes10 = { mwqmLookupMPN.Tubes10 } " +
        $"Tubes1 = { mwqmLookupMPN.Tubes1 } " +
        $"Tubes01 = { mwqmLookupMPN.Tubes01 }";

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(MWQMLookupMPN mwqmLookupMPN) { parameters }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        if (mwqmLookupMPN.MWQMLookupMPNID == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMLookupMPNID"));
        }

        if (mwqmLookupMPN.Tubes10 < 0 || mwqmLookupMPN.Tubes10 > 5)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes10", "0", "5"));
        }

        if (mwqmLookupMPN.Tubes1 < 0 || mwqmLookupMPN.Tubes1 > 5)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes1", "0", "5"));
        }

        if (mwqmLookupMPN.Tubes01 < 0 || mwqmLookupMPN.Tubes01 > 5)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes01", "0", "5"));
        }

        if (mwqmLookupMPN.MPN_100ml < 1 || mwqmLookupMPN.MPN_100ml > 99000000)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MPN_100ml", "1", "99000000"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);

        MWQMLookupMPN mwqmLookupMPNJSON = (from c in webAllMWQMLookupMPNs.MWQMLookupMPNList
                                           where c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID
                                           select c).FirstOrDefault();

        if (mwqmLookupMPNJSON == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMLookupMPN", "MWQMLookupMPNID", mwqmLookupMPN.MWQMLookupMPNID.ToString()));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        MWQMLookupMPN MWQMLookupMPNExist = (from c in dbLocal.MWQMLookupMPNs
                                            where c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID
                                            select c).FirstOrDefault();
        if (MWQMLookupMPNExist == null)
        {

            MWQMLookupMPNExist = new MWQMLookupMPN()
            {
                DBCommand = DBCommandEnum.Modified,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                MPN_100ml = mwqmLookupMPN.MPN_100ml,
                MWQMLookupMPNID = mwqmLookupMPN.MWQMLookupMPNID,
                Tubes01 = mwqmLookupMPN.Tubes01,
                Tubes1 = mwqmLookupMPN.Tubes1,
                Tubes10 = mwqmLookupMPN.Tubes10,
            };

            dbLocal.MWQMLookupMPNs.Add(MWQMLookupMPNExist);
        }
        else
        {
            MWQMLookupMPNExist.DBCommand = DBCommandEnum.Modified;
            MWQMLookupMPNExist.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            MWQMLookupMPNExist.LastUpdateDate_UTC = DateTime.UtcNow;
            MWQMLookupMPNExist.MPN_100ml = mwqmLookupMPN.MPN_100ml;
            MWQMLookupMPNExist.Tubes10 = mwqmLookupMPN.Tubes10;
            MWQMLookupMPNExist.Tubes1 = mwqmLookupMPN.Tubes1;
            MWQMLookupMPNExist.Tubes01 = mwqmLookupMPN.Tubes01;
        }

        try
        {
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "MWQMLookupMPN", ex.Message));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        await CSSPCreateGzFileService.SetLocal(true);

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
        {
            ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(MWQMLookupMPNExist));
    }
}
