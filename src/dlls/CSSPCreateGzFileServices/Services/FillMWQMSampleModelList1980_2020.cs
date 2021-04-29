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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillMWQMSampleModelList1980_2020(List<MWQMSampleModel> MWQMSampleModelList, TVItem TVItem)
        {
            List<MWQMSample> MWQMSampleList = await GetWQMSampleListFromSubsector1980_2020(TVItem);
            List<MWQMSampleLanguage> MWQMSampleLanguageList = await GetWQMSampleLanguageListFromSubsector1980_2020(TVItem);

            foreach(MWQMSample mwqmSample in MWQMSampleList)
            {
                MWQMSampleModel mwqmSampleModel = new MWQMSampleModel()
                {
                    MWQMSample = mwqmSample,
                    MWQMSampleLanguageList = MWQMSampleLanguageList.Where(c => c.MWQMSampleID == mwqmSample.MWQMSampleID).ToList(),
                };

                MWQMSampleModelList.Add(mwqmSampleModel);
            }
        }
    }
}