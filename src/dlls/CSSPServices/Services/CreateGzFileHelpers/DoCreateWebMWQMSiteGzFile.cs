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
        private async Task<ActionResult<bool>> DoCreateWebMWQMSiteGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(SubsectorTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Subsector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString())));
            }

            WebMWQMSite webMWQMSite = new WebMWQMSite();

            try
            {
                webMWQMSite.MWQMSiteList = await GetMWQMSiteListFromSubsector(tvItem);
                webMWQMSite.MWQMSiteStartEndDateList = await GetMWQMSiteStartEndDateListFromSubsector(tvItem);

                await DoStore<WebMWQMSite>(webMWQMSite, $"WebMWQMSite_{SubsectorTVItemID}.gz");
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
