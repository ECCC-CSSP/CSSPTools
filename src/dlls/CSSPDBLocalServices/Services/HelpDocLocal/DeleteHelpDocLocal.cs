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
        public async Task<ActionResult<HelpDocLocalModel>> DeleteHelpDocLocal(HelpDocLocalModel helpDocLocalModel)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(HelpDocLocalModel helpDocLocalModel)";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            if (helpDocLocalModel.HelpDoc.HelpDocID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "HelpDocID"));
            }

            //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)HelpDocModel.HelpDoc.DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            //if (string.IsNullOrWhiteSpace(helpDocLocalModel.HelpDoc.DocKey))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DocKey"));
            //}

            //string retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)helpDocLocalModel.HelpDoc.Language);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            //}

            //if (string.IsNullOrWhiteSpace(helpDocLocalModel.HelpDoc.DocHTMLText))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DocHTMLText"));
            //}

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

            HelpDoc helpDocJSON = (from c in webAllHelpDocs.HelpDocList
                                   where c.HelpDocID == helpDocLocalModel.HelpDoc.HelpDocID
                                   select c).FirstOrDefault();

            if (helpDocJSON == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", helpDocLocalModel.HelpDoc.HelpDocID.ToString()));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            HelpDoc HelpDocExist = (from c in dbLocal.HelpDocs
                                    where c.HelpDocID == helpDocLocalModel.HelpDoc.HelpDocID
                                    select c).FirstOrDefault();
            if (HelpDocExist == null)
            {
                int HelpDocIDNew = (from c in dbLocal.HelpDocs
                                    where c.HelpDocID < 0
                                    orderby c.HelpDocID descending
                                    select c.HelpDocID).FirstOrDefault() - 1;

                helpDocLocalModel.HelpDoc.DBCommand = DBCommandEnum.Deleted;
                helpDocLocalModel.HelpDoc.HelpDocID = HelpDocIDNew;
                helpDocLocalModel.HelpDoc.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                helpDocLocalModel.HelpDoc.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.HelpDocs.Add(helpDocLocalModel.HelpDoc);
            }
            else
            {
                HelpDocExist.DBCommand = DBCommandEnum.Deleted;
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

            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllHelpDocs, 0);
            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
            {
                ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(helpDocLocalModel));
        }
    }
}