namespace CSSPDBLocalServices;

public partial class EmailLocalService : ControllerBase, IEmailLocalService
{
    public async Task<ActionResult<Email>> AddEmailLocalAsync(Email email)
    {
        string parameters = "";
        if (email != null)
        {
            parameters = $" --  EmailAddress = { email.EmailAddress ?? "--" } " +
                $"EmailType = { email.EmailType.ToString() ?? "--" }";
        }

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(Email email) { parameters }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        #region Check Email
        if (email == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Email"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        if (email.EmailID != 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "EmailID", "0"));
        }

        if (string.IsNullOrWhiteSpace(email.EmailAddress))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "EmailAddress"));
        }
        else
        {
            if (email.EmailAddress.Length > 255)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "EmailAddress", "255"));
            }
        }

        if (!IsValidEmail(email.EmailAddress))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotAValidEmail, email.EmailAddress));
        }

        string retStr = enums.EnumTypeOK(typeof(EmailTypeEnum), (int?)email.EmailType);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "EmailType"));
        }
        #endregion Check Email

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        WebAllEmails webAllEmails = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllEmails>(WebTypeEnum.WebAllEmails, 0);

        Email emailJSON = (from c in webAllEmails.EmailList
                           where c.EmailAddress == email.EmailAddress
                           select c).FirstOrDefault();

        if (emailJSON != null)
        {
            return await Task.FromResult(Ok(emailJSON));
        }

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        await TVItemLocalService.AddTVItemParentLocalAsync(webRoot.TVItemModelParentList.OrderBy(c => c.TVItem.TVLevel).ToList());

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        string TVTextEN = $"{ email.EmailAddress }";
        string TVTextFR = $"{ email.EmailAddress }";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(webRoot.TVItemModel.TVItem, TVTypeEnum.Email, TVTextEN, TVTextFR);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        int EmailIDNew = (from c in dbLocal.Emails
                          where c.EmailID < 0
                          orderby c.EmailID ascending
                          select c.EmailID).FirstOrDefault() - 1;

        try
        {
            email.DBCommand = DBCommandEnum.Created;
            email.EmailID = EmailIDNew;
            email.EmailTVItemID = tvItemModel.TVItem.TVItemID;
            email.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            email.LastUpdateDate_UTC = DateTime.UtcNow;

            dbLocal.Emails.Add(email);
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Email", ex.Message));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));


        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllEmails, TVItemID = 0 },
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

        return await Task.FromResult(Ok(email));
    }
}
