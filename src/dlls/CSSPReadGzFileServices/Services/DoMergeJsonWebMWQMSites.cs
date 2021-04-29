/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using LoggedInServices;
using CSSPWebModels;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebMWQMSites(WebMWQMSites WebMWQMSites, WebMWQMSites WebMWQMSitesLocal)
        {
            List<MWQMSiteModel> MWQMSiteModelList = (from c in WebMWQMSitesLocal.MWQMSiteModelList
                                                     where c.MWQMSite.DBCommand != DBCommandEnum.Original
                                                     select c).ToList();

            foreach (MWQMSiteModel mwqmRunModel in MWQMSiteModelList)
            {
                MWQMSiteModel mwqmRunModelOriginal = WebMWQMSites.MWQMSiteModelList.Where(c => c.MWQMSite.MWQMSiteID == mwqmRunModel.MWQMSite.MWQMSiteID).FirstOrDefault();
                if (mwqmRunModelOriginal == null)
                {
                    WebMWQMSites.MWQMSiteModelList.Add(mwqmRunModelOriginal);
                }
                else
                {
                    mwqmRunModelOriginal = mwqmRunModel;
                }

                List<TVFileModel> TVFileModelList = (from c in mwqmRunModel.TVFileModelList
                                                     where c.TVItem.DBCommand != DBCommandEnum.Original
                                                     || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                     || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                     select c).ToList();

                foreach (TVFileModel tvFileModel in TVFileModelList)
                {
                    TVFileModel tvFileModelOriginal = mwqmRunModel.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                    if (tvFileModelOriginal == null)
                    {
                        mwqmRunModel.TVFileModelList.Add(tvFileModel);
                    }
                    else
                    {
                        tvFileModelOriginal = tvFileModel;
                    }
                }
            }
        }
    }
}
