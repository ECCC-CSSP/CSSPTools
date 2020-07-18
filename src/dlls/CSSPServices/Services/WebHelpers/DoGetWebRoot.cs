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
        private async Task<ActionResult<WebRoot>> DoGetWebRoot()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemRoot = await GetTVItemRoot();

            if (tvItemRoot == null)
            {
                return BadRequest("TVItemRoot could not be found");
            }

            int TVItemID = tvItemRoot.TVItemID;

            WebRoot webRoot = new WebRoot();

            try
            {
                webRoot.TVItem = tvItemRoot;
                webRoot.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItemID);
                webRoot.TVItemStatList = await GetTVItemStatListWithTVItemID(TVItemID);
                webRoot.MapInfoList = await GetMapInfoListWithTVItemID(TVItemID);
                webRoot.MapInfoPointList = await GetMapInfoPointListWithTVItemID(TVItemID);
                webRoot.TVFileList = await GetTVFileListWithTVItemID(TVItemID);
                webRoot.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItemID);
                webRoot.TVItemCountryList = await GetTVItemChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);
                webRoot.TVItemLanguageCountryList = await GetTVItemLanguageChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);
                webRoot.TVItemStatCountryList = await GetTVItemStatChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);
                webRoot.MapInfoCountryList = await GetMapInfoChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);
                webRoot.MapInfoPointCountryList = await GetMapInfoPointChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);

                await DoStore<WebRoot>(webRoot, "WebRoot.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webRoot));
        }
    }
}
