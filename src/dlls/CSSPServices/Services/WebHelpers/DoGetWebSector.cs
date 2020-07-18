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
        private async Task<ActionResult<WebSector>> DoGetWebSector(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Sector)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Sector }]");
            }

            WebSector webSector = new WebSector();

            try
            {
                webSector.TVItem = tvItem;
                webSector.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItemID);
                webSector.TVItemStatList = await GetTVItemStatListWithTVItemID(TVItemID);
                webSector.MapInfoList = await GetMapInfoListWithTVItemID(TVItemID);
                webSector.MapInfoPointList = await GetMapInfoPointListWithTVItemID(TVItemID);
                webSector.TVFileList = await GetTVFileListWithTVItemID(TVItemID);
                webSector.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItemID);
                webSector.TVItemSubsectorList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Subsector);
                webSector.TVItemLanguageSubsectorList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Subsector);
                webSector.TVItemStatSubsectorList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Subsector);
                webSector.MapInfoSubsectorList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Subsector);
                webSector.MapInfoPointSubsectorList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Subsector);
                webSector.TVItemMikeScenarioList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);
                webSector.TVItemLanguageMikeScenarioList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);
                webSector.TVItemStatMikeScenarioList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);
                webSector.MapInfoMikeScenarioList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);
                webSector.MapInfoPointMikeScenarioList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);

                await DoStore<WebSector>(webSector, $"WebSector_{TVItemID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webSector));
        }
    }
}
