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
        private async Task<ActionResult<WebCountry>> DoGetWebCountry(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Country)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Country }]");
            }

            WebCountry webCountry = new WebCountry();

            try
            {
                webCountry.TVItem = tvItem;

                webCountry.TVItemLanguageList = GetTVItemLanguageListWithTVItemID(TVItemID);

                webCountry.TVItemStatList = GetTVItemStatListWithTVItemID(TVItemID);

                webCountry.MapInfoList = GetMapInfoListWithTVItemID(TVItemID);

                webCountry.MapInfoPointList = GetMapInfoPointListWithTVItemID(TVItemID);

                webCountry.TVFileList = GetTVFileListWithTVItemID(TVItemID);

                webCountry.TVFileLanguageList = GetTVFileLanguageListWithTVItemID(TVItemID);

                webCountry.TVItemProvinceList = GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);

                webCountry.TVItemLanguageProvinceList = GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);

                webCountry.TVItemStatProvinceList = GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);

                webCountry.MapInfoProvinceList = GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);

                webCountry.MapInfoPointProvinceList = GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webCountry));
        }
    }
}
