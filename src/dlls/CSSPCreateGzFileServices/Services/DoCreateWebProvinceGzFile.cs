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
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemProvince = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (tvItemProvince == null || tvItemProvince.TVType != TVTypeEnum.Province)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString())));
            }

            WebProvince webProvince = new WebProvince();

            try
            {
                await FillTVItemModel(webProvince.TVItemModel, tvItemProvince);

                await FillParentListTVItemModelList(webProvince.TVItemParentList, tvItemProvince);

                await FillChildListTVItemModelList(webProvince.TVItemAreaList, tvItemProvince, TVTypeEnum.Area);

                webProvince.SamplingPlanList = await GetSamplingPlanListWithProvinceTVItemID(tvItemProvince.TVItemID);

                await DoStore<WebProvince>(webProvince, $"WebProvince_{ProvinceTVItemID}.gz");
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
