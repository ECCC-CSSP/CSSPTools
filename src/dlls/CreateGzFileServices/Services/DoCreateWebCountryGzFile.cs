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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebCountryGzFile(int CountryTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(CountryTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Country)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", CountryTVItemID.ToString(), "TVType", TVTypeEnum.Country.ToString())));
            }

            WebCountry webCountry = new WebCountry();

            try
            {
                webCountry.TVItem = tvItem;
                webCountry.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(CountryTVItemID);
                webCountry.TVItemStatList = await GetTVItemStatListWithTVItemID(CountryTVItemID);
                webCountry.MapInfoList = await GetMapInfoListWithTVItemID(CountryTVItemID);
                webCountry.MapInfoPointList = await GetMapInfoPointListWithTVItemID(CountryTVItemID);
                webCountry.TVFileList = await GetTVFileListWithTVItemID(CountryTVItemID);
                webCountry.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(CountryTVItemID);
                webCountry.TVItemProvinceList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);
                webCountry.TVItemLanguageProvinceList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);
                webCountry.TVItemStatProvinceList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);
                webCountry.MapInfoProvinceList = await GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);
                webCountry.MapInfoPointProvinceList = await GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Province);
                webCountry.EmailDistributionListList = await GetEmailDistributionListListUnderCountry(tvItem.TVItemID);
                webCountry.EmailDistributionListLanguageList = await GetEmailDistributionListLanguageListUnderCountry(tvItem.TVItemID);
                webCountry.EmailDistributionListContactList = await GetEmailDistributionListContactListUnderCountry(tvItem.TVItemID);
                webCountry.EmailDistributionListContactLanguageList = await GetEmailDistributionListContactLanguageListUnderCountry(tvItem.TVItemID);

                await DoStore<WebCountry>(webCountry, $"WebCountry_{CountryTVItemID}.gz");
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
