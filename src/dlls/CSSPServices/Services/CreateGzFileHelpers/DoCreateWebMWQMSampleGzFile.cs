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
        private async Task<ActionResult<bool>> DoCreateWebMWQMSampleGzFile(int SubsectorTVItemID, int Year)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(SubsectorTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Subsector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString())));
            }

            WebMWQMSample webMWQMSample = new WebMWQMSample();

            try
            {
                webMWQMSample.MWQMSampleList = await GetWQMSampleListFromSubsector10Years(tvItem, Year);
                webMWQMSample.MWQMSampleLanguageList = await GetWQMSampleLanguageListFromSubsector10Years(tvItem, Year);

                await DoStore<WebMWQMSample>(webMWQMSample, $"WebMWQMSample_{SubsectorTVItemID}_{Year}_{Year + 9}.gz");
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
