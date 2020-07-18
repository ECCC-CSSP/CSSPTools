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
        private async Task<ActionResult<WebProvince>> DoGetWebProvince(int TVItemID)
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

            WebProvince webProvince = new WebProvince();

            try
            {
                webProvince.TVItem = tvItem;
                webProvince.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItemID);
                webProvince.TVItemStatList = await GetTVItemStatListWithTVItemID(TVItemID);
                webProvince.MapInfoList = await GetMapInfoListWithTVItemID(TVItemID);
                webProvince.MapInfoPointList = await GetMapInfoPointListWithTVItemID(TVItemID);
                webProvince.TVFileList = await GetTVFileListWithTVItemID(TVItemID);
                webProvince.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItemID);
                webProvince.TVItemAreaList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);
                webProvince.TVItemLanguageAreaList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);
                webProvince.TVItemStatAreaList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);
                webProvince.MapInfoAreaList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);
                webProvince.MapInfoPointAreaList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);
                webProvince.SamplingPlanList = await GetSamplingPlanListWithProvinceTVItemID(tvItem.TVItemID);

                await DoStore<WebProvince>(webProvince, $"WebProvince_{TVItemID}.gz");
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
