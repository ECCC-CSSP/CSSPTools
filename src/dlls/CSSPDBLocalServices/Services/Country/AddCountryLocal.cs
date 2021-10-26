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
        public async Task<ActionResult<CountryLocalModel>> AddCountryLocal(CountryLocalModel countryLocalModel)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(CountryLocalModel countryLocalModel)";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            #region Check countryLocalModel
            if (countryLocalModel.TVItemParent == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "countryLocalModel.TVItemParent"));
            }
            if (countryLocalModel.TVItem == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "countryLocalModel.TVItem"));
            }

            if (countryLocalModel.TVItemLanguageList == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "countryLocalModel.TVItemLanguageList"));
            }

            if (countryLocalModel.MapInfoLocalModelList == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "countryLocalModel.MapInfoModelList"));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            string TVTextEN = countryLocalModel.TVItemLanguageList[0].TVText;
            string TVTextFR = countryLocalModel.TVItemLanguageList[1].TVText;

            if (string.IsNullOrWhiteSpace(TVTextEN))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "countryLocalModel.TVItemLanguageList[0].TVText"));
            }

            if (string.IsNullOrWhiteSpace(TVTextFR))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "countryLocalModel.TVItemLanguageList[1].TVText"));
            }

            if (countryLocalModel.TVItem.TVType != TVTypeEnum.Country)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "countryLocalModel.TVItem.TVType", TVTypeEnum.Country.ToString()));
            }

            if (countryLocalModel.TVItemParent.TVType != TVTypeEnum.Root)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "countryLocalModel.TVItemParent.TVType", TVTypeEnum.Root.ToString()));
            }

            if (countryLocalModel.TVItemParent.TVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "countryLocalModel.TVItemParent.TVItemID"));
            }
            #endregion Check countryLocalModel

            // fill TVItemParents
            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            await TVItemLocalService.AddTVItemParentLocal(webRoot.TVItemModelParentList.OrderBy(c => c.TVItem.TVLevel).ToList());

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            CountryLocalModel countryLocalModelNew = new CountryLocalModel();

            // Add new TVItem and TVItemLanguageList
            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(countryLocalModel.TVItemParent, countryLocalModel.TVItem.TVType, TVTextEN, TVTextFR);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            countryLocalModelNew.TVItem = tvItemModel.TVItem;
            countryLocalModelNew.TVItemLanguageList = tvItemModel.TVItemLanguageList;

            // Add new MapInfoLocalModelList
            foreach (MapInfoLocalModel mapInfoLocalModel in countryLocalModel.MapInfoLocalModelList)
            {
                var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(countryLocalModel.TVItemParent, countryLocalModel.TVItem);

                if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

                MapInfoModel mapInfoModelLocal = (MapInfoModel)((OkObjectResult)actionMapInfoModel.Result).Value;

                if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

                countryLocalModelNew.MapInfoLocalModelList.Add(mapInfoLocalModel);
            }

            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllCountries, 0);
            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
            {
                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebRoot, 0);
            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
            {
                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, tvItemModel.TVItem.TVItemID);
            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
            {
                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(countryLocalModel));
        }
    }
}