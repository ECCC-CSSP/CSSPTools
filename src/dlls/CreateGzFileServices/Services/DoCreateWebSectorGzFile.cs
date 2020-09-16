/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

            TVItem tvItemSector = await GetTVItemWithTVItemID(SectorTVItemID);

            if (tvItemSector == null || tvItemSector.TVType != TVTypeEnum.Sector)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SectorTVItemID.ToString(), "TVType", TVTypeEnum.Sector.ToString())));
            }

            WebSector webSector = new WebSector();

            try
            {
                await FillTVItemModel(webSector.TVItemModel, tvItemSector);

                await FillChildTVItemModel(webSector.TVItemSubsectorList, tvItemSector, TVTypeEnum.Subsector);

                await FillChildTVItemModel(webSector.TVItemMikeScenarioList, tvItemSector, TVTypeEnum.MikeScenario);

                await DoStore<WebSector>(webSector, $"WebSector_{SectorTVItemID}.gz");
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
