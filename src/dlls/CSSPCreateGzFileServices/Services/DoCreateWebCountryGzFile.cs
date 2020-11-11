/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
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

            TVItem tvItemCountry = await GetTVItemWithTVItemID(CountryTVItemID);

            if (tvItemCountry == null || tvItemCountry.TVType != TVTypeEnum.Country)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", CountryTVItemID.ToString(), "TVType", TVTypeEnum.Country.ToString())));
            }

            WebCountry webCountry = new WebCountry();

            try
            {
                await FillTVItemModel(webCountry.TVItemModel, tvItemCountry);

                await FillParentListTVItemModelList(webCountry.TVItemParentList, tvItemCountry);

                await FillChildListTVItemModelList(webCountry.TVItemProvinceList, tvItemCountry, TVTypeEnum.Province);

                webCountry.EmailDistributionListList = await GetEmailDistributionListListUnderCountry(tvItemCountry.TVItemID);
                webCountry.EmailDistributionListLanguageList = await GetEmailDistributionListLanguageListUnderCountry(tvItemCountry.TVItemID);
                webCountry.EmailDistributionListContactList = await GetEmailDistributionListContactListUnderCountry(tvItemCountry.TVItemID);
                webCountry.EmailDistributionListContactLanguageList = await GetEmailDistributionListContactLanguageListUnderCountry(tvItemCountry.TVItemID);

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
