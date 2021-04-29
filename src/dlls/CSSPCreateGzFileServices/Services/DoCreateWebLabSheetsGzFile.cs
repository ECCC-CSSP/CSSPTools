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
        private async Task<ActionResult<bool>> DoCreateWebLabSheetsGzFile(int SubsectorTVItemID)
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

            WebLabSheets webLabSheets = new WebLabSheets();

            try
            {
                await FillTVItemModelAndParentTVItemModelList(webLabSheets.TVItemStatMapModel, webLabSheets.TVItemStatModelParentList, TVItemSubsector);

                await FillLabSheetModelList(webLabSheets.LabSheetModelList, TVItemSubsector);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebLabSheets>(webLabSheets, $"{ WebTypeEnum.WebLabSheets }_{ SubsectorTVItemID }.gz");
                }
                else
                {
                    await DoStore<WebLabSheets>(webLabSheets, $"{ WebTypeEnum.WebLabSheets }_{ SubsectorTVItemID }.gz");
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
