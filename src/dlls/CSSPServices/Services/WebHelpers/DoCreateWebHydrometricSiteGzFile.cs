/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPWebService : ControllerBase, ICSSPWebService
    {
        private async Task<ActionResult<bool>> DoCreateWebHydrometricSite(int ProvinceTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Province)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString())));
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

                await DoStore<WebHydrometricSite>(webHydrometricSite, $"WebHydrometricSite_{ProvinceTVItemID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return await Task.FromResult(BadRequest($"{ ex.Message } { inner }"));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}
