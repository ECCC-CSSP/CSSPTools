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
using CSSPWebModels;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebHydrometricSitesGzFile(int ProvinceTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemProvince = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (TVItemProvince == null || TVItemProvince.TVType != TVTypeEnum.Province)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString())));
            }

            WebHydrometricSites webHydrometricSites  = new WebHydrometricSites();

            try
            {
                await FillTVItemModelAndParentTVItemModelList(webHydrometricSites.TVItemModel, webHydrometricSites.TVItemModelParentList, TVItemProvince);

                await FillHydrometricSiteModelList(webHydrometricSites.HydrometricSiteModelList, TVItemProvince);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebHydrometricSites>(webHydrometricSites, $"{ WebTypeEnum.WebHydrometricSites }_{ ProvinceTVItemID }.gz");
                }
                else
                {
                    await DoStore<WebHydrometricSites>(webHydrometricSites, $"{ WebTypeEnum.WebHydrometricSites }_{ ProvinceTVItemID }.gz");
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
