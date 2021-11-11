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
    public partial class CountryLocalService : ControllerBase, ICountryLocalService
    {
        public async Task<ActionResult<TVItemModel>> DeleteCountryLocal(int TVItemID)
        {
            string parameters = $" --  TVItemID = { TVItemID }";

            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int TVItemID) { parameters }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            if (TVItemID == 0)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItemModel tvItemModelToDelete = (from c in webRoot.TVItemModelCountryList
                                               where c.TVItem.TVItemID == TVItemID
                                               select c).FirstOrDefault();

            if (tvItemModelToDelete == null)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemModel", "TVItemID", $"{ TVItemID }"));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            await HelperLocalService.CheckIfChildExist(webRoot.TVItemModel.TVItem, tvItemModelToDelete.TVItem);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            var actionTVItemModelRes = await TVItemLocalService.DeleteTVItemLocal(webRoot.TVItemModel.TVItem, tvItemModelToDelete);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            TVItemModel tvItemModelDeleted = (TVItemModel)((OkObjectResult)actionTVItemModelRes.Result).Value;

            tvItemModelToDelete.TVItem = tvItemModelDeleted.TVItem;
            tvItemModelToDelete.TVItemLanguageList = tvItemModelDeleted.TVItemLanguageList;

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            foreach (MapInfoModel mapInfoModel in tvItemModelToDelete.MapInfoModelList)
            {
                var actionMapInfoModelRes = await MapInfoLocalService.DeleteMapInfoLocal(webRoot.TVItemModel.TVItem, tvItemModelToDelete.TVItem, TVTypeEnum.Country, mapInfoModel.MapInfo.MapInfoDrawType);

                if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

                MapInfoModel mapInfoModelDeleted = (MapInfoModel)((OkObjectResult)actionMapInfoModelRes.Result).Value;

                mapInfoModel.MapInfo = mapInfoModelDeleted.MapInfo;
                mapInfoModel.MapInfoPointList = mapInfoModelDeleted.MapInfoPointList;
            }

            List<ToRecreate> ToRecreateList = new List<ToRecreate>()
            {
                new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
                new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
                new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = tvItemModelToDelete.TVItem.TVItemID },
            };

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

            return await Task.FromResult(Ok(tvItemModelToDelete));
        }
    }
}