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
        private async Task<ActionResult<bool>> DoCreateWebSectorGzFile(int SectorTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(SectorTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Sector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SectorTVItemID.ToString(), "TVType", TVTypeEnum.Sector.ToString())));
            }

            WebSector webSector = new WebSector();

            try
            {
                webSector.TVItem = tvItem;
                webSector.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(SectorTVItemID);
                webSector.TVItemStatList = await GetTVItemStatListWithTVItemID(SectorTVItemID);
                webSector.MapInfoList = await GetMapInfoListWithTVItemID(SectorTVItemID);
                webSector.MapInfoPointList = await GetMapInfoPointListWithTVItemID(SectorTVItemID);
                webSector.TVFileList = await GetTVFileListWithTVItemID(SectorTVItemID);
                webSector.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(SectorTVItemID);
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

                await DoStore<WebSector>(webSector, $"WebSector_{SectorTVItemID}.gz");
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
