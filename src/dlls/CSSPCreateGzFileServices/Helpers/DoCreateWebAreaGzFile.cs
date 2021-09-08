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
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebAreaGzFile(int AreaTVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(AreaTVItemID: { AreaTVItemID })";
            await CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemArea = await GetTVItemWithTVItemID(AreaTVItemID);

            if (TVItemArea == null || TVItemArea.TVType != TVTypeEnum.Area)
            {
                await CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_, 
                    "TVItem", "TVType", TVTypeEnum.Area.ToString()), new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebArea webArea = new WebArea();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webArea.TVItemModel, webArea.TVItemModelParentList, TVItemArea)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webArea.TVItemModelSectorList, TVItemArea, TVTypeEnum.Sector)) return await Task.FromResult(false);

                if (!await FillFileModelList(webArea.TVFileModelList, TVItemArea)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebArea>(webArea, $"{ WebTypeEnum.WebArea }_{ AreaTVItemID }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebArea>(webArea, $"{ WebTypeEnum.WebArea }_{ AreaTVItemID }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                await CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
