/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSSPWebModels;
using CSSPDBModels;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebTideDataValueGzFile(int TideSiteTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            TVItem TVItemTideSite = await GetTVItemWithTVItemID(TideSiteTVItemID);

            if (TVItemTideSite == null || TVItemTideSite.TVType != TVTypeEnum.TideSite)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", TideSiteTVItemID.ToString(), "TVType", TVTypeEnum.TideSite.ToString())));
            }

            WebTideDataValue webTideDataValue  = new WebTideDataValue();

            try
            {
                await FillTVItemModel(webTideDataValue.TVItemModel, TVItemTideSite);

                await FillParentListTVItemModelList(webTideDataValue.TVItemParentList, TVItemTideSite);

                webTideDataValue.TideDataValueList = await GetTideDataValueListForTideSite(TVItemTideSite.TVItemID);

                await DoStore<WebTideDataValue>(webTideDataValue, $"{ WebTypeEnum.WebTideDataValue }_{ TideSiteTVItemID }.gz");
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
