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
        private async Task<ActionResult<bool>> DoCreateWebMWQMSamples2021_2060GzFile(int SubsectorTVItemID)
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
                await FillTVItemModelAndParentTVItemModelList(webMWQMSamples.TVItemStatMapModel, webMWQMSamples.TVItemStatModelParentList, TVItemSubsector);

                await FillMWQMSampleModelList2021_2060(webMWQMSamples.MWQMSampleModelList, TVItemSubsector);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebMWQMSamples>(webMWQMSamples, $"{ WebTypeEnum.WebMWQMSamples2021_2060 }_{ SubsectorTVItemID }.gz");
                }
                else
                {
                    await DoStore<WebMWQMSamples>(webMWQMSamples, $"{ WebTypeEnum.WebMWQMSamples2021_2060 }_{ SubsectorTVItemID }.gz");
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
