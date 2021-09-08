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
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;
using System.Reflection;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> FillMWQMSampleModelList2021_2060(List<MWQMSampleModel> MWQMSampleModelList, TVItem TVItem)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<MWQMSampleModel> MWQMSampleModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }";
            await CSSPLogService.FunctionLog(FunctionName);

            List<MWQMSample> MWQMSampleList = await GetWQMSampleListFromSubsector2021_2060(TVItem);
            List<MWQMSampleLanguage> MWQMSampleLanguageList = await GetWQMSampleLanguageListFromSubsector2021_2060(TVItem);

            foreach(MWQMSample mwqmSample in MWQMSampleList)
            {
                MWQMSampleModel mwqmSampleModel = new MWQMSampleModel()
                {
                    MWQMSample = mwqmSample,
                    MWQMSampleLanguageList = MWQMSampleLanguageList.Where(c => c.MWQMSampleID == mwqmSample.MWQMSampleID).ToList(),
                };

                MWQMSampleModelList.Add(mwqmSampleModel);
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}