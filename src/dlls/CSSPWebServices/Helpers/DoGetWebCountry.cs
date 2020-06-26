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

            TVItem tvItem = await GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Country)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Country }]");
            }

            WebCountry webCountry = new WebCountry();

            try
            {
                webCountry.TVItem = tvItem;
                webCountry.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItemID);
                webCountry.TVItemStatList = await GetTVItemStatListWithTVItemID(TVItemID);
                webCountry.MapInfoList = await GetMapInfoListWithTVItemID(TVItemID);
                webCountry.MapInfoPointList = await GetMapInfoPointListWithTVItemID(TVItemID);
                webCountry.TVFileList = await GetTVFileListWithTVItemID(TVItemID);
                webCountry.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItemID);
                webCountry.TVItemProvinceList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);
                webCountry.TVItemLanguageProvinceList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);
                webCountry.TVItemStatProvinceList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);
                webCountry.MapInfoProvinceList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);
                webCountry.MapInfoPointProvinceList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);
                webCountry.EmailDistributionListList = await GetEmailDistributionListListUnderCountry(tvItem.TVItemID);
                webCountry.EmailDistributionListLanguageList = await GetEmailDistributionListLanguageListUnderCountry(tvItem.TVItemID);
                webCountry.EmailDistributionListContactList = await GetEmailDistributionListContactListUnderCountry(tvItem.TVItemID);
                webCountry.EmailDistributionListContactLanguageList = await GetEmailDistributionListContactLanguageListUnderCountry(tvItem.TVItemID);
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
