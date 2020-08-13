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
        private async Task<ActionResult<bool>> DoCreateWebAreaGzFile(int AreaTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(AreaTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Area)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_, 
                    "TVItem", AreaTVItemID.ToString(), "TVType", TVTypeEnum.Area.ToString())));
            }

            WebArea webArea = new WebArea();

            try
            {
                webArea.TVItem = tvItem;
                webArea.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(AreaTVItemID);
                webArea.TVItemStatList = await GetTVItemStatListWithTVItemID(AreaTVItemID);
                webArea.MapInfoList = await GetMapInfoListWithTVItemID(AreaTVItemID);
                webArea.MapInfoPointList = await GetMapInfoPointListWithTVItemID(AreaTVItemID);
                webArea.TVFileList = await GetTVFileListWithTVItemID(AreaTVItemID);
                webArea.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(AreaTVItemID);
                webArea.TVItemSectorList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Sector);
                webArea.TVItemLanguageSectorList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Sector);
                webArea.TVItemStatSectorList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Sector);
                webArea.MapInfoSectorList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Sector);
                webArea.MapInfoPointSectorList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Sector);

                await DoStore<WebArea>(webArea, $"WebArea_{AreaTVItemID}.gz");
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
