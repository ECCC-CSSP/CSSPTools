/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebMWQMSamples1980_2020(WebMWQMSamples WebMWQMSamples, WebMWQMSamples WebMWQMSamplesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebMWQMSamples WebMWQMSamples, WebMWQMSamples WebMWQMSamplesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            List<MWQMSampleModel> MWQMSampleModelList = (from c in WebMWQMSamplesLocal.MWQMSampleModelList
                                                         where c.MWQMSample.MWQMSampleID != 0
                                                         && c.MWQMSample.DBCommand != DBCommandEnum.Original
                                                         select c).ToList();

            foreach (MWQMSampleModel mwqmSampleModel in MWQMSampleModelList)
            {
                MWQMSampleModel mwqmSampleModelOriginal = WebMWQMSamples.MWQMSampleModelList.Where(c => c.MWQMSample.MWQMSampleID == mwqmSampleModel.MWQMSample.MWQMSampleID).FirstOrDefault();
                if (mwqmSampleModelOriginal == null)
                {
                    WebMWQMSamples.MWQMSampleModelList.Add(mwqmSampleModelOriginal);
                }
                else
                {
                    mwqmSampleModelOriginal = mwqmSampleModel;
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);
        }
    }
}
