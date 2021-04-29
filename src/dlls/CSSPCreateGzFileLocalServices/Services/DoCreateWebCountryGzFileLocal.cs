/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSSPWebModels;
using CSSPDBModels;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<ActionResult<bool>> DoCreateWebCountryGzFileLocal(int CountryTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemCountry = await GetTVItemWithTVItemID(CountryTVItemID);

            if (TVItemCountry == null || TVItemCountry.TVType != TVTypeEnum.Country)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", CountryTVItemID.ToString(), "TVType", TVTypeEnum.Country.ToString())));
            }

            WebCountry webCountry = new WebCountry();

            try
            {
                await FillTVItemModelLocal(webCountry.TVItemStatMapModel, TVItemCountry);

                await FillParentListTVItemModelListLocal(webCountry.TVItemStatParentList, TVItemCountry);

                await FillChildListTVItemModelListLocal(webCountry.TVItemProvinceList, TVItemCountry, TVTypeEnum.Province);

                await FillChildListTVItemModelListLocal(webCountry.TVItemFileList, TVItemCountry, TVTypeEnum.File);

                await FillChildListTVItemModelListLocal(webCountry.TVItemRainExceedanceList, TVItemCountry, TVTypeEnum.RainExceedance);

                webCountry.EmailDistributionListList = await GetEmailDistributionListListUnderCountry(TVItemCountry.TVItemID);
                webCountry.EmailDistributionListLanguageList = await GetEmailDistributionListLanguageListUnderCountry(TVItemCountry.TVItemID);
                webCountry.EmailDistributionListContactList = await GetEmailDistributionListContactListUnderCountry(TVItemCountry.TVItemID);
                webCountry.EmailDistributionListContactLanguageList = await GetEmailDistributionListContactLanguageListUnderCountry(TVItemCountry.TVItemID);

                DoStoreLocal<WebCountry>(webCountry, $"{ WebTypeEnum.WebCountry }_{ CountryTVItemID }.gz");
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
