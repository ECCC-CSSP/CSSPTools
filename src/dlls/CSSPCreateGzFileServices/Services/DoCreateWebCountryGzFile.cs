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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebCountryGzFile(int CountryTVItemID)
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
                await FillTVItemModelAndParentTVItemModelList(webCountry.TVItemStatMapModel, webCountry.TVItemStatModelParentList, TVItemCountry);

                await FillChildListTVItemModelList(webCountry.TVItemStatMapModelProvinceList, TVItemCountry, TVTypeEnum.Province);

                await FillFileModelList(webCountry.TVFileModelList, TVItemCountry);

                await FillRainExceedanceModelList(webCountry.RainExceedanceModelList, TVItemCountry);

                await FillEmailDistributionListModelList(webCountry.EmailDistributionListModelList, TVItemCountry);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebCountry>(webCountry, $"{ WebTypeEnum.WebCountry }_{ CountryTVItemID }.gz");
                }
                else
                {
                    await DoStore<WebCountry>(webCountry, $"{ WebTypeEnum.WebCountry }_{ CountryTVItemID }.gz");
                }
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
