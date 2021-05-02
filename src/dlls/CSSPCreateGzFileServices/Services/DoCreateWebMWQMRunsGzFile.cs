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
        private async Task<ActionResult<bool>> DoCreateWebMWQMRunsGzFile(int SubsectorTVItemID)
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

            WebMWQMRuns webMWQMRuns = new WebMWQMRuns();

            try
            {
                await FillTVItemModelAndParentTVItemModelList(webMWQMRuns.TVItemModel, webMWQMRuns.TVItemModelParentList, TVItemSubsector);

                await FillMWQMRunModelList(webMWQMRuns.MWQMRunModelList, TVItemSubsector, TVTypeEnum.MWQMRun);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebMWQMRuns>(webMWQMRuns, $"{ WebTypeEnum.WebMWQMRuns }_{ SubsectorTVItemID }.gz");
                }
                else
                {
                    await DoStore<WebMWQMRuns>(webMWQMRuns, $"{ WebTypeEnum.WebMWQMRuns }_{ SubsectorTVItemID }.gz");
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
