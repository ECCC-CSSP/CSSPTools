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
        private async Task<bool> DoCreateWebSubsectorGzFile(int SubsectorTVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(SubsectorTVItemID: { SubsectorTVItemID })";
            CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemSubsector = await GetTVItemWithTVItemID(SubsectorTVItemID);

            if (TVItemSubsector == null || TVItemSubsector.TVType != TVTypeEnum.Subsector)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString()));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebSubsector webSubsector = new WebSubsector();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webSubsector.TVItemModel, webSubsector.TVItemModelParentList, TVItemSubsector)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webSubsector.TVItemModelClassificationList, TVItemSubsector, TVTypeEnum.Classification)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webSubsector.TVItemModelMWQMSiteList, TVItemSubsector, TVTypeEnum.MWQMSite)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webSubsector.TVItemModelMWQMRunList, TVItemSubsector, TVTypeEnum.MWQMRun)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webSubsector.TVItemModelPolSourceSiteList, TVItemSubsector, TVTypeEnum.PolSourceSite)) return await Task.FromResult(false);

                if (!await FillFileModelList(webSubsector.TVFileModelList, TVItemSubsector)) return await Task.FromResult(false);

                webSubsector.MWQMAnalysisReportParameterList = await GetMWQMAnalysisReportParameterListUnderSubsector(SubsectorTVItemID);
                webSubsector.MWQMSubsector = await GetMWQMSubsector(SubsectorTVItemID);
                webSubsector.MWQMSubsectorLanguageList = await GetMWQMSubsectorLanguageList(SubsectorTVItemID);
                webSubsector.UseOfSiteList = await GetUseOfSiteList(SubsectorTVItemID);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebSubsector>(webSubsector, $"{ WebTypeEnum.WebSubsector }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebSubsector>(webSubsector, $"{ WebTypeEnum.WebSubsector }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError($"{ ex.Message } { inner }");
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
