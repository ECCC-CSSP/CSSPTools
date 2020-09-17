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
        private async Task<ActionResult<bool>> DoCreateWebMWQMSampleGzFile(int SubsectorTVItemID, int Year)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemSubsector = await GetTVItemWithTVItemID(SubsectorTVItemID);

            if (tvItemSubsector == null || tvItemSubsector.TVType != TVTypeEnum.Subsector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString())));
            }

            WebMWQMSample webMWQMSample = new WebMWQMSample();

            try
            {
                await FillParentListTVItemModelList(webMWQMSample.TVItemParentList, tvItemSubsector);

                webMWQMSample.MWQMSampleList = await GetWQMSampleListFromSubsector10Years(tvItemSubsector, Year);
                webMWQMSample.MWQMSampleLanguageList = await GetWQMSampleLanguageListFromSubsector10Years(tvItemSubsector, Year);

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
