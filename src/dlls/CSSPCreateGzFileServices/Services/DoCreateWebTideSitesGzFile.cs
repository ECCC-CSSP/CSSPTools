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
        private async Task<ActionResult<bool>> DoCreateWebTideSitesGzFile(int ProvinceTVItemID)
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

            WebTideSites webTideSites = new WebTideSites();

            try
            {
                await FillTVItemModelAndParentTVItemModelList(webTideSites.TVItemStatMapModel, webTideSites.TVItemStatModelParentList, TVItemProvince);

                await FillTideSiteModelList(webTideSites.TideSiteModelList, TVItemProvince);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebTideSites>(webTideSites, $"{ WebTypeEnum.WebTideSites }_{ ProvinceTVItemID }.gz");
                }
                else
                {
                    await DoStore<WebTideSites>(webTideSites, $"{ WebTypeEnum.WebTideSites }_{ ProvinceTVItemID }.gz");
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
