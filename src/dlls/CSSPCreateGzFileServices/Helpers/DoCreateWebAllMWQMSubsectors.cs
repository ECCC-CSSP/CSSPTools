/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> DoCreateWebAllMWQMSubsectorsGzFile()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            WebAllMWQMSubsectors webAllMWQMSubsectors = new WebAllMWQMSubsectors();

            try
            {
                List<MWQMSubsector> mwqmSubsectorList = await GetAllMWQMSubsector();
                List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = await GetAllMWQMSubsectorLanguage();
                
                foreach(MWQMSubsector mwqmSubsector in mwqmSubsectorList)
                {
                    webAllMWQMSubsectors.MWQMSubsectorModelList.Add(new MWQMSubsectorModel()
                    {
                        MWQMSubsector = mwqmSubsector,
                        MWQMSubsectorLanguageList = (from c in mwqmSubsectorLanguageList
                                                     where c.MWQMSubsectorID == mwqmSubsector.MWQMSubsectorID
                                                     orderby c.Language
                                                     select c).ToList()
                    });
                }

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebAllMWQMSubsectors>(webAllMWQMSubsectors, $"{ WebTypeEnum.WebAllMWQMSubsectors }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebAllMWQMSubsectors>(webAllMWQMSubsectors, $"{ WebTypeEnum.WebAllMWQMSubsectors }.gz")) return await Task.FromResult(false);
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
