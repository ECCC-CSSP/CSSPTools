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
        private async Task<ActionResult<bool>> DoCreateWebMunicipalities(int ProvinceTVItemID)
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

            WebMunicipalities webMunicipalities = new WebMunicipalities();

            try
            {
                webMunicipalities.TVItemList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);
                webMunicipalities.TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);
                webMunicipalities.TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);
                webMunicipalities.MapInfoList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);
                webMunicipalities.MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);

                await DoStore<WebMunicipalities>(webMunicipalities, $"WebMunicipalities_{ProvinceTVItemID}.gz");
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
