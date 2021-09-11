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
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebSectorGzFile(int SectorTVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(SectorTVItemID: { SectorTVItemID })";
            CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemSector = await GetTVItemWithTVItemID(SectorTVItemID);

            if (TVItemSector == null || TVItemSector.TVType != TVTypeEnum.Sector)
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SectorTVItemID.ToString(), "TVType", TVTypeEnum.Sector.ToString()), new[] { "" }));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebSector webSector = new WebSector();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webSector.TVItemModel, webSector.TVItemModelParentList, TVItemSector)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webSector.TVItemModelSubsectorList, TVItemSector, TVTypeEnum.Subsector)) return await Task.FromResult(false);

                if (!await FillFileModelList(webSector.TVFileModelList, TVItemSector)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebSector>(webSector, $"{ WebTypeEnum.WebSector }_{ SectorTVItemID }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebSector>(webSector, $"{ WebTypeEnum.WebSector }_{ SectorTVItemID }.gz")) return await Task.FromResult(false);
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
