/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CSSPWebModels;
using CSSPDBModels;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<ActionResult<bool>> DoCreateWebAreaGzFileLocal(int AreaTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemArea = await GetTVItemWithTVItemID(AreaTVItemID);

            if (TVItemArea == null || TVItemArea.TVType != TVTypeEnum.Area)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_, 
                    "TVItem", AreaTVItemID.ToString(), "TVType", TVTypeEnum.Area.ToString())));
            }

            WebArea webArea = new WebArea();

            try
            {
                await FillTVItemModelLocal(webArea.TVItemStatMapModel, TVItemArea);

                await FillParentListTVItemModelListLocal(webArea.TVItemStatModelParentList, TVItemArea);

                await FillChildListTVItemModelListLocal(webArea.TVItemStatMapModelSectorList, TVItemArea, TVTypeEnum.Sector);

                await FillChildListTVItemModelListLocal(webArea.TVItemFileList, TVItemArea, TVTypeEnum.File);

                DoStoreLocal<WebArea>(webArea, $"{ WebTypeEnum.WebArea }_{ AreaTVItemID }.gz");
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
