/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSSPLocalLoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPWebModels;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using CSSPHelperModels;
using CSSPLogServices;
using System.Reflection;
using System.Security.Cryptography;
using CSSPReadGzFileServices;
using CSSPCreateGzFileServices;

namespace CSSPDBLocalServices
{
    public partial class EmailLocalService : ControllerBase, IEmailLocalService
    {
        public async Task<ActionResult<EmailLocalModel>> AddEmailLocal(EmailLocalModel emailLocalModel)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(EmailLocalModel emailLocalModel)";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            #region Check Email
            if (emailLocalModel.Email.EmailID != 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "EmailID", "0"));
            }

            //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)EmailModel.Email.DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            //if (EmailModel.Email.EmailTVItemID == 0)
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "EmailTVItemID"));
            //}

            if (string.IsNullOrWhiteSpace(emailLocalModel.Email.EmailAddress))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "EmailAddress"));
            }

            string retStr = enums.EnumTypeOK(typeof(EmailTypeEnum), (int?)emailLocalModel.Email.EmailType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "EmailType"));
            }
            #endregion Check Email

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebAllEmails webAllEmails = await CSSPReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, 0);

            Email emailJSON = (from c in webAllEmails.EmailList
                                   where c.EmailAddress == emailLocalModel.Email.EmailAddress
                                   select c).FirstOrDefault();

            if (emailJSON != null)
            {
                return await Task.FromResult(Ok(new EmailLocalModel() { Email = emailJSON }));
            }

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            await TVItemLocalService.AddTVItemParentLocal(webRoot.TVItemModelParentList.OrderBy(c => c.TVItem.TVLevel).ToList());

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            string TVTextEN = $"{ emailLocalModel.Email.EmailAddress }";
            string TVTextFR = $"{ emailLocalModel.Email.EmailAddress }";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(webRoot.TVItemModel.TVItem, TVTypeEnum.Email, TVTextEN, TVTextFR);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            int EmailIDNew = (from c in dbLocal.Emails
                                where c.EmailID < 0
                                orderby c.EmailID descending
                                select c.EmailID).FirstOrDefault() - 1;

            try
            {
                emailLocalModel.Email.DBCommand = DBCommandEnum.Created;
                emailLocalModel.Email.EmailID = EmailIDNew;
                emailLocalModel.Email.EmailTVItemID = tvItemModel.TVItem.TVItemID;
                emailLocalModel.Email.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                emailLocalModel.Email.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.Emails.Add(emailLocalModel.Email);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Email", ex.Message));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllEmails, 0);
            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
            {
                ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(emailLocalModel));
        }
    }
}