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
        private async Task<ActionResult<bool>> DoCreateWebClimateSiteGzFile(int ProvinceTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemProvince = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (tvItemProvince == null || tvItemProvince.TVType != TVTypeEnum.Province)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString())));
            }

            WebClimateSite webClimateSite  = new WebClimateSite();

            try
            {
                webClimateSite.ClimateSiteList = await GetClimateSiteListUnderProvince(tvItemProvince);

                await FillParentListTVItemModelList(webClimateSite.TVItemParentList, tvItemProvince);

                await FillChildListTVItemModelList(webClimateSite.TVItemClimateSiteList, tvItemProvince, TVTypeEnum.ClimateSite);

                await DoStore<WebClimateSite>(webClimateSite, $"WebClimateSite_{ProvinceTVItemID}.gz");
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
