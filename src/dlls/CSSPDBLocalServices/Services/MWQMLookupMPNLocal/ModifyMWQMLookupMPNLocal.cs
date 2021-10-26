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
        public async Task<ActionResult<MWQMLookupMPNLocalModel>> ModifyMWQMLookupMPNLocal(MWQMLookupMPNLocalModel mwqmLookupMPNLocalModel)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(MWQMLookupMPNLocalModel mwqmLookupMPNLocalModel)";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            if (mwqmLookupMPNLocalModel.MWQMLookupMPN.MWQMLookupMPNID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMLookupMPNID"));
            }

            //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)MWQMLookupMPNModel.MWQMLookupMPN.DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            if (mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes10 < 0 || mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes10 > 5)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes10", "0", "5"));
            }

            if (mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes1 < 0 || mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes1 > 5)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes1", "0", "5"));
            }

            if (mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes01 < 0 || mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes01 > 5)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes01", "0", "5"));
            }

            if (mwqmLookupMPNLocalModel.MWQMLookupMPN.MPN_100ml < 1 || mwqmLookupMPNLocalModel.MWQMLookupMPN.MPN_100ml > 99000000)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MPN_100ml", "1", "99000000"));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);

            MWQMLookupMPN mwqmLookupMPNJSON = (from c in webAllMWQMLookupMPNs.MWQMLookupMPNList
                                               where c.MWQMLookupMPNID == mwqmLookupMPNLocalModel.MWQMLookupMPN.MWQMLookupMPNID
                                               select c).FirstOrDefault();

            if (mwqmLookupMPNJSON == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMLookupMPN", "MWQMLookupMPNID", mwqmLookupMPNLocalModel.MWQMLookupMPN.MWQMLookupMPNID.ToString()));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            MWQMLookupMPN MWQMLookupMPNExist = (from c in dbLocal.MWQMLookupMPNs
                                                where c.MWQMLookupMPNID == mwqmLookupMPNLocalModel.MWQMLookupMPN.MWQMLookupMPNID
                                                select c).FirstOrDefault();
            if (MWQMLookupMPNExist == null)
            {
                int MWQMLookupMPNIDNew = (from c in dbLocal.MWQMLookupMPNs
                                          where c.MWQMLookupMPNID < 0
                                          orderby c.MWQMLookupMPNID descending
                                          select c.MWQMLookupMPNID).FirstOrDefault() - 1;

                mwqmLookupMPNLocalModel.MWQMLookupMPN.DBCommand = DBCommandEnum.Modified;
                mwqmLookupMPNLocalModel.MWQMLookupMPN.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                mwqmLookupMPNLocalModel.MWQMLookupMPN.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.MWQMLookupMPNs.Add(mwqmLookupMPNLocalModel.MWQMLookupMPN);
            }
            else
            {
                MWQMLookupMPNExist.DBCommand = DBCommandEnum.Modified;
                MWQMLookupMPNExist.Tubes10 = mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes10;
                MWQMLookupMPNExist.Tubes1 = mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes1;
                MWQMLookupMPNExist.Tubes01 = mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes01;
                MWQMLookupMPNExist.MPN_100ml = mwqmLookupMPNLocalModel.MWQMLookupMPN.MPN_100ml;
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

            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
            {
                ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(mwqmLookupMPNLocalModel));
        }
    }
}