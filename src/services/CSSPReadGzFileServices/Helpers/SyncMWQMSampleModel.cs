/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private void SyncMWQMSampleModel(MWQMSampleModel mwqmSampleModelOriginal, MWQMSampleModel mwqmSampleModelLocal)
        {
            if (mwqmSampleModelLocal != null)
            {
                if (mwqmSampleModelLocal.MWQMSample != null)
                {
                    mwqmSampleModelOriginal.MWQMSample = mwqmSampleModelLocal.MWQMSample;
                }
                if (mwqmSampleModelLocal.MWQMSampleLanguageList != null)
                {
                    mwqmSampleModelOriginal.MWQMSampleLanguageList = mwqmSampleModelLocal.MWQMSampleLanguageList;
                }
            }
        }
    }
}
