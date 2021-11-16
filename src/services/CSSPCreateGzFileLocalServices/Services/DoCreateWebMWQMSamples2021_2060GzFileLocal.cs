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

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<ActionResult<bool>> DoCreateWebMWQMSamples2021_2060GzFileLocal(int SubsectorTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemSubsector = await GetTVItemWithTVItemID(SubsectorTVItemID);
            
            if (TVItemSubsector == null || TVItemSubsector.TVType != TVTypeEnum.Subsector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString())));
            }

            WebMWQMSamples webMWQMSamples = new WebMWQMSamples();

            try
            {
                await FillTVItemModelLocal(webMWQMSamples.TVItemModel, TVItemSubsector);

                await FillParentListTVItemModelListLocal(webMWQMSamples.TVItemParentList, TVItemSubsector);

                webMWQMSamples.MWQMSampleList = await GetWQMSampleListFromSubsector2021_2060(TVItemSubsector);
                webMWQMSamples.MWQMSampleLanguageList = await GetWQMSampleLanguageListFromSubsector2021_2060(TVItemSubsector);

                DoStoreLocal<WebMWQMSamples>(webMWQMSamples, $"{ WebTypeEnum.WebMWQMSamples2021_2060 }_{ SubsectorTVItemID }.gz");
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
