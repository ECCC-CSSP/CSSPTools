/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public partial class WebService : ControllerBase, IWebService
    {
        private async Task<ActionResult<WebProvince>> DoGetWebProvince(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Province)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Province }]");
            }

            WebProvince webProvince = new WebProvince();

            try
            {
                webProvince.TVItem = tvItem;

                webProvince.TVItemLanguageList = GetTVItemLanguageListWithTVItemID(TVItemID);

                webProvince.TVItemStatList = GetTVItemStatListWithTVItemID(TVItemID);

                webProvince.MapInfoList = GetMapInfoListWithTVItemID(TVItemID);

                webProvince.MapInfoPointList = GetMapInfoPointListWithTVItemID(TVItemID);

                webProvince.TVFileList = GetTVFileListWithTVItemID(TVItemID);

                webProvince.TVFileLanguageList = GetTVFileLanguageListWithTVItemID(TVItemID);

                webProvince.TVItemAreaList = GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);

                webProvince.TVItemLanguageAreaList = GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);

                webProvince.TVItemStatAreaList = GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);

                webProvince.MapInfoAreaList = GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);

                webProvince.MapInfoPointAreaList = GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);

                webProvince.TVItemMunicipalityList = GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);

                webProvince.TVItemLanguageMunicipalityList = GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);

                webProvince.TVItemStatMunicipalityList = GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);

                webProvince.MapInfoMunicipalityList = GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);

                webProvince.MapInfoPointMunicipalityList = GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);

                webProvince.SamplingPlanList = GetSamplingPlanListWithProvinceTVItemID(tvItem.TVItemID);
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webProvince));
        }
    }
}
