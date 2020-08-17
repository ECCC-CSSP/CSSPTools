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
        private async Task<ActionResult<bool>> DoCreateWebProvinceGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Province)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString())));
            }

            WebProvince webProvince = new WebProvince();

            try
            {
                webProvince.TVItem = tvItem;
                webProvince.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(ProvinceTVItemID);
                webProvince.TVItemStatList = await GetTVItemStatListWithTVItemID(ProvinceTVItemID);
                webProvince.MapInfoList = await GetMapInfoListWithTVItemID(ProvinceTVItemID);
                webProvince.MapInfoPointList = await GetMapInfoPointListWithTVItemID(ProvinceTVItemID);
                webProvince.TVFileList = await GetTVFileListWithTVItemID(ProvinceTVItemID);
                webProvince.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(ProvinceTVItemID);
                webProvince.TVItemAreaList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);
                webProvince.TVItemLanguageAreaList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);
                webProvince.TVItemStatAreaList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);
                webProvince.MapInfoAreaList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);
                webProvince.MapInfoPointAreaList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Area);
                webProvince.SamplingPlanList = await GetSamplingPlanListWithProvinceTVItemID(tvItem.TVItemID);

                await DoStore<WebProvince>(webProvince, $"WebProvince_{ProvinceTVItemID}.gz");
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
