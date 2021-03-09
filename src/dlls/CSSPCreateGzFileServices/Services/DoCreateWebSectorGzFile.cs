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
        private async Task<ActionResult<bool>> DoCreateWebSectorGzFile(int SectorTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem TVItemSector = await GetTVItemWithTVItemID(SectorTVItemID);

            if (TVItemSector == null || TVItemSector.TVType != TVTypeEnum.Sector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SectorTVItemID.ToString(), "TVType", TVTypeEnum.Sector.ToString())));
            }

            WebSector webSector = new WebSector();

            try
            {
                await FillTVItemModel(webSector.TVItemModel, TVItemSector);

                await FillParentListTVItemModelList(webSector.TVItemParentList, TVItemSector);

                await FillChildListTVItemModelList(webSector.TVItemSubsectorList, TVItemSector, TVTypeEnum.Subsector);

                await FillChildListTVItemModelList(webSector.TVItemFileList, TVItemSector, TVTypeEnum.File);

                await DoStore<WebSector>(webSector, $"{ WebTypeEnum.WebSector }_{ SectorTVItemID }.gz");
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
