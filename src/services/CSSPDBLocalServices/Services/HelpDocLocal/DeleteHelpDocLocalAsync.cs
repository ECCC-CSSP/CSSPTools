namespace CSSPDBLocalServices;

public partial class HelpDocLocalService : ControllerBase, IHelpDocLocalService
{
    public async Task<ActionResult<HelpDoc>> DeleteHelpDocLocalAsync(int HelpDocID)
    {
        string parameters = $" --  HelpDocID = { HelpDocID } ";

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int HelpDocID) { parameters }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        if (HelpDocID == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "HelpDocID"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

        HelpDoc helpDocJSON = (from c in webAllHelpDocs.HelpDocList
                               where c.HelpDocID == HelpDocID
                               select c).FirstOrDefault();

        if (helpDocJSON == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", HelpDocID.ToString()));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        HelpDoc HelpDocExist = (from c in dbLocal.HelpDocs
                                where c.HelpDocID == HelpDocID
                                select c).FirstOrDefault();
        if (HelpDocExist == null)
        {
            HelpDocExist = new HelpDoc()
            {
                DBCommand = DBCommandEnum.Deleted,
                DocHTMLText = helpDocJSON.DocHTMLText,
                DocKey = helpDocJSON.DocKey,
                HelpDocID = helpDocJSON.HelpDocID,
                Language = helpDocJSON.Language,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
            };

            dbLocal.HelpDocs.Add(HelpDocExist);
        }
        else
        {
            HelpDocExist.DBCommand = DBCommandEnum.Deleted;
            HelpDocExist.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            HelpDocExist.LastUpdateDate_UTC = DateTime.UtcNow;
        }

        try
        {
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "HelpDoc", ex.Message));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        await CSSPCreateGzFileService.SetLocal(true);

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllHelpDocs, 0);
        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
        {
            ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(HelpDocExist));
    }
}
