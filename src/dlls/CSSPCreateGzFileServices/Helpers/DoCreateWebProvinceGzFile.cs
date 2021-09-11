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
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebProvinceGzFile(int ProvinceTVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(ProvinceTVItemID: { ProvinceTVItemID })";
            CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemProvince = await GetTVItemWithTVItemID(ProvinceTVItemID);

            if (TVItemProvince == null || TVItemProvince.TVType != TVTypeEnum.Province)
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()), new[] { "" }));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebProvince webProvince = new WebProvince();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webProvince.TVItemModel, webProvince.TVItemModelParentList, TVItemProvince)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webProvince.TVItemModelAreaList, TVItemProvince, TVTypeEnum.Area)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webProvince.TVItemModelMunicipalityList, TVItemProvince, TVTypeEnum.Municipality)) return await Task.FromResult(false);

                if (!await FillFileModelList(webProvince.TVFileModelList, TVItemProvince)) return await Task.FromResult(false);

                if (!await FillSamplingPlanModelList(webProvince.SamplingPlanModelList, TVItemProvince)) return await Task.FromResult(false);

                webProvince.MunicipalityWithInfrastructureTVItemIDList = await GetMunicipalityWithInfrastructureTVItemIDList(TVItemProvince);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebProvince>(webProvince, $"{ WebTypeEnum.WebProvince }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebProvince>(webProvince, $"{ WebTypeEnum.WebProvince }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
