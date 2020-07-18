/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class WebService : ControllerBase, IWebService
    {
        private async Task<ActionResult<WebHydrometricSite>> DoGetWebHydrometricSite(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Province)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Province }]");
            }

            WebHydrometricSite webHydrometricSite  = new WebHydrometricSite();

            try
            {
                webHydrometricSite.HydrometricSiteList = await GetHydrometricSiteListUnderProvince(tvItem);
                webHydrometricSite.TVItemList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.HydrometricSite);
                webHydrometricSite.TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.HydrometricSite);
                webHydrometricSite.MapInfoList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.HydrometricSite);
                webHydrometricSite.MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.HydrometricSite);
                webHydrometricSite.RatingCurveList = await GetRatingCurveListUnderProvince(tvItem);
                webHydrometricSite.RatingCurveValueList = await GetRatingCurveValueListUnderProvince(tvItem);

                await DoStore<WebHydrometricSite>(webHydrometricSite, $"WebHydrometricSite_{TVItemID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webHydrometricSite));
        }
    }
}
