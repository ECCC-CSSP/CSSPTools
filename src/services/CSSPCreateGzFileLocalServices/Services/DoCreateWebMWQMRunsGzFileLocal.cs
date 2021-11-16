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
        private async Task<ActionResult<bool>> DoCreateWebMWQMRunsGzFileLocal(int SubsectorTVItemID)
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
                await FillTVItemModelLocal(webMWQMRuns.TVItemModel, TVItemSubsector);

                await FillChildListTVItemModelListLocal(webMWQMRuns.TVItemMWQMRunList, TVItemSubsector, TVTypeEnum.MWQMRun);

                await FillParentListTVItemModelListLocal(webMWQMRuns.TVItemParentList, TVItemSubsector);

                await FillChildListTVItemMWQMRunModelListLocal(webMWQMRuns.MWQMRunModelList, TVItemSubsector, TVTypeEnum.MWQMRun);

                DoStoreLocal<WebMWQMRuns>(webMWQMRuns, $"{ WebTypeEnum.WebMWQMRuns }_{ SubsectorTVItemID }.gz");
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
