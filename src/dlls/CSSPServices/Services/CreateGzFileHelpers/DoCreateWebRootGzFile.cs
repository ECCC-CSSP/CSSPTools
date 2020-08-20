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
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebRootGzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemRoot = await GetTVItemRoot();

            if (tvItemRoot == null)
            {
                return await Task.FromResult(BadRequest(CSSPCultureServicesRes.TVItemRootCouldNotBeFound));
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
                return await Task.FromResult(BadRequest($"{ ex.Message } { inner }"));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}