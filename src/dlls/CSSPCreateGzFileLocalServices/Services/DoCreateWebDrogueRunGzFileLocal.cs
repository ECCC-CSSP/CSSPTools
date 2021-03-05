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
        private async Task<ActionResult<bool>> DoCreateWebDrogueRunGzFileLocal(int SubsectorTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem TVItemSubsector = await GetTVItemWithTVItemID(SubsectorTVItemID);

            if (TVItemSubsector == null || TVItemSubsector.TVType != TVTypeEnum.Subsector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString())));
            }

            WebDrogueRun webDrogueRun = new WebDrogueRun();

            try
            {
                await FillParentListTVItemModelListLocal(webDrogueRun.TVItemParentList, TVItemSubsector);

                await FillTVItemModelLocal(webDrogueRun.TVItemModel, TVItemSubsector);

                webDrogueRun.DrogueRunList = await GetDrogueRunListUnderProvince(TVItemSubsector.TVItemID);
                webDrogueRun.DrogueRunPositionList = await GetDrogueRunPositionListUnderProvince(TVItemSubsector.TVItemID);

                DoStoreLocal<WebDrogueRun>(webDrogueRun, $"{ WebTypeEnum.WebDrogueRun }_{ SubsectorTVItemID }.gz");
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
