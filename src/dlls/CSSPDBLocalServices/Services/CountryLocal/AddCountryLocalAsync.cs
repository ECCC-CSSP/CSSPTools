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
        public async Task<ActionResult<TVItemModel>> AddCountryLocalAsync(int ParentTVItemID)
        {
            string parameters = $" --  ParentTVItemID = { ParentTVItemID }";

            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID) { parameters }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            if (ParentTVItemID == 0)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVItemID"));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItemModel tvItemModelParent = webRoot.TVItemModel;

            await TVItemLocalService.AddTVItemParentLocalAsync(webRoot.TVItemModelParentList.OrderBy(c => c.TVItem.TVLevel).ToList());

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            TVItemModel tvItemModelNew = new TVItemModel();

            List<TVItemModel> tvItemModelCountryList = webRoot.TVItemModelCountryList;

            string TVTextEN = await HelperLocalService.GetUniqueTVTextAsync(tvItemModelCountryList, LanguageEnum.en, "New Country");
            string TVTextFR = await HelperLocalService.GetUniqueTVTextAsync(tvItemModelCountryList, LanguageEnum.fr, "Nouveau Pays");

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemModelParent.TVItem, TVTypeEnum.Country, TVTextEN, TVTextFR);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            tvItemModelNew = tvItemModel;

            List<MapInfoModel> mapInfoModelList = new List<MapInfoModel>();

            foreach (TVItemModel tvItemModelForMapInfo in tvItemModelCountryList)
            {
                mapInfoModelList.AddRange(tvItemModelForMapInfo.MapInfoModelList);
            }

            var actionMapInfoModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverageAsync(tvItemModelParent.TVItem, tvItemModelNew.TVItem, TVTypeEnum.Country, MapInfoDrawTypeEnum.Point);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            MapInfoModel mapInfoModelPoint = (MapInfoModel)((OkObjectResult)actionMapInfoModelPoint.Result).Value;

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            tvItemModelNew.MapInfoModelList.Add(mapInfoModelPoint);

            var actionMapInfoModelPolygon = await MapInfoLocalService.AddMapInfoLocalFromAverageAsync(tvItemModelParent.TVItem, tvItemModelNew.TVItem, TVTypeEnum.Country, MapInfoDrawTypeEnum.Polygon);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            MapInfoModel mapInfoModelPolygon = (MapInfoModel)((OkObjectResult)actionMapInfoModelPolygon.Result).Value;

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            tvItemModelNew.MapInfoModelList.Add(mapInfoModelPolygon);

            List<ToRecreate> ToRecreateList = new List<ToRecreate>()
            {
                new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
                new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
                new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = tvItemModel.TVItem.TVItemID },
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

            return await Task.FromResult(Ok(tvItemModelNew));
        }
    }
}