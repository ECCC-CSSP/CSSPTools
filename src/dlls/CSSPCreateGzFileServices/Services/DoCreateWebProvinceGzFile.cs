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
        private async Task<ActionResult<bool>> DoCreateWebProvinceGzFile(int ProvinceTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem TVItemProvince = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (TVItemProvince == null || TVItemProvince.TVType != TVTypeEnum.Province)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString())));
            }

            WebProvince webProvince = new WebProvince();

            try
            {
                await FillTVItemModel(webProvince.TVItemModel, TVItemProvince);

                await FillParentListTVItemModelList(webProvince.TVItemParentList, TVItemProvince);

                await FillChildListTVItemModelList(webProvince.TVItemAreaList, TVItemProvince, TVTypeEnum.Area);

                await FillChildListTVItemModelList(webProvince.TVItemFileList, TVItemProvince, TVTypeEnum.File);

                webProvince.SamplingPlanList = await GetSamplingPlanListWithProvinceTVItemID(TVItemProvince.TVItemID);

                await DoStore<WebProvince>(webProvince, $"{ WebTypeEnum.WebProvince }_{ ProvinceTVItemID }.gz");
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
