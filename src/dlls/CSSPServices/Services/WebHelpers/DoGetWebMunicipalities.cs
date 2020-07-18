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
        private async Task<ActionResult<WebMunicipalities>> DoGetWebMunicipalities(int TVItemID)
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

            WebMunicipalities webMunicipalities = new WebMunicipalities();

            try
            {
                webMunicipalities.TVItemList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);
                webMunicipalities.TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);
                webMunicipalities.TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);
                webMunicipalities.MapInfoList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);
                webMunicipalities.MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Municipality);

                await DoStore<WebMunicipalities>(webMunicipalities, $"WebMunicipalities_{TVItemID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webMunicipalities));
        }
    }
}
