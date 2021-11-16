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

            //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)MWQMLookupMPNModel.DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

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

            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);

            MWQMLookupMPN mwqmLookupMPNJSON = (from c in webAllMWQMLookupMPNs.MWQMLookupMPNList
                                               where c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID
                                               select c).FirstOrDefault();

            if (mwqmLookupMPNJSON == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMLookupMPN", "MWQMLookupMPNID", mwqmLookupMPN.MWQMLookupMPNID.ToString()));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            MWQMLookupMPN MWQMLookupMPNExist = (from c in dbLocal.MWQMLookupMPNs
                                                where c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID
                                                select c).FirstOrDefault();
            if (MWQMLookupMPNExist == null)
            {
                int MWQMLookupMPNIDNew = (from c in dbLocal.MWQMLookupMPNs
                                          where c.MWQMLookupMPNID < 0
                                          orderby c.MWQMLookupMPNID ascending
                                          select c.MWQMLookupMPNID).FirstOrDefault() - 1;

                mwqmLookupMPN.DBCommand = DBCommandEnum.Modified;
                mwqmLookupMPN.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                mwqmLookupMPN.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.MWQMLookupMPNs.Add(mwqmLookupMPN);
            }
            else
            {
                MWQMLookupMPNExist.DBCommand = DBCommandEnum.Modified;
                MWQMLookupMPNExist.Tubes10 = mwqmLookupMPN.Tubes10;
                MWQMLookupMPNExist.Tubes1 = mwqmLookupMPN.Tubes1;
                MWQMLookupMPNExist.Tubes01 = mwqmLookupMPN.Tubes01;
                MWQMLookupMPNExist.MPN_100ml = mwqmLookupMPN.MPN_100ml;
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

            var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
            {
                ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(mwqmLookupMPN));
        }
    }
}