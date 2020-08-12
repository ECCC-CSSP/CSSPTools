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
        private async Task<ActionResult<bool>> DoCreateWebClimateSite(int ProvinceTVItemID)
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

            WebClimateSite webClimateSite  = new WebClimateSite();

            try
            {
                webClimateSite.ClimateSiteList = await GetClimateSiteListUnderProvince(tvItem);
                webClimateSite.TVItemList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.ClimateSite);
                webClimateSite.TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.ClimateSite);
                webClimateSite.MapInfoList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.ClimateSite);
                webClimateSite.MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.ClimateSite);

                await DoStore<WebClimateSite>(webClimateSite, $"WebClimateSite_{ProvinceTVItemID}.gz");
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
