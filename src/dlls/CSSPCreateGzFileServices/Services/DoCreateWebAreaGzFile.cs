/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CSSPWebModels;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebAreaGzFile(int AreaTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemArea = await GetTVItemWithTVItemID(AreaTVItemID);

            if (tvItemArea == null || tvItemArea.TVType != TVTypeEnum.Area)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_, 
                    "TVItem", AreaTVItemID.ToString(), "TVType", TVTypeEnum.Area.ToString())));
            }

            WebArea webArea = new WebArea();

            try
            {
                await FillTVItemModel(webArea.TVItemModel, tvItemArea);

                await FillParentListTVItemModelList(webArea.TVItemParentList, tvItemArea);

                await FillChildListTVItemModelList(webArea.TVItemSectorList, tvItemArea, TVTypeEnum.Sector);

                await DoStore<WebArea>(webArea, $"WebArea_{AreaTVItemID}.gz");
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
