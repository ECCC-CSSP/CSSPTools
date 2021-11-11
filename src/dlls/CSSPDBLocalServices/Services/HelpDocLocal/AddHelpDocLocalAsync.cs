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
    public partial class HelpDocLocalService : ControllerBase, IHelpDocLocalService
    {
        public async Task<ActionResult<HelpDoc>> AddHelpDocLocalAsync(HelpDoc helpDoc)
        {
            string parameters = $" --  DocKey = { helpDoc.DocKey ?? "--" } " +
            $"Language = { helpDoc.Language.ToString() ?? "--" }";

            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(HelpDoc helpDoc) { parameters }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            if (helpDoc.HelpDocID != 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "HelpDocID", "0"));
            }

            //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)HelpDocModel.DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            if (string.IsNullOrWhiteSpace(helpDoc.DocKey))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DocKey"));
            }

            string retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)helpDoc.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            }

            if (string.IsNullOrWhiteSpace(helpDoc.DocHTMLText))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DocHTMLText"));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

            HelpDoc helpDocJSON = (from c in webAllHelpDocs.HelpDocList
                                   where c.DocKey == helpDoc.DocKey
                                   select c).FirstOrDefault();

            if (helpDocJSON != null)
            {
                return await Task.FromResult(Ok(helpDocJSON));
            }

            int HelpDocIDNew = (from c in dbLocal.HelpDocs
                                where c.HelpDocID < 0
                                orderby c.HelpDocID ascending
                                select c.HelpDocID).FirstOrDefault() - 1;

            helpDoc.DBCommand = DBCommandEnum.Created;
            helpDoc.HelpDocID = HelpDocIDNew;
            helpDoc.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            helpDoc.LastUpdateDate_UTC = DateTime.UtcNow;

            dbLocal.HelpDocs.Add(helpDoc);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "HelpDoc", ex.Message));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllHelpDocs, 0);
            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
            {
                ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(helpDoc));
        }
    }
}