/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class WebService : ControllerBase, IWebService
    {
        private async Task<ActionResult<WebPolSourceSite>> DoGetWebPolSourceSite(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Subsector)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Subsector }]");
            }

            WebPolSourceSite webPolSourceSite = new WebPolSourceSite();

            try
            {
                webPolSourceSite.PolSourceSiteList = await GetPolSourceSiteListFromSubsector(tvItem);
                webPolSourceSite.PolSourceObservationList = await GetPolSourceObservationListFromSubsector(tvItem);
                webPolSourceSite.PolSourceObservationIssueList = await GetPolSourceObservationIssueListFromSubsector(tvItem);
                webPolSourceSite.PolSourceSiteEffectList = await GetPolSourceSiteEffectListFromSubsector(tvItem);
                webPolSourceSite.PolSourceSiteEffectTermList = await GetPolSourceSiteEffectTermListFromSubsector(tvItem);
                webPolSourceSite.PolSourceSiteCivicAddressList = await GetPolSourceSiteAddressListFromSubsector(tvItem);

                await DoStore<WebPolSourceSite>(webPolSourceSite, $"WebPolSourceSite_{TVItemID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webPolSourceSite));
        }
    }
}
