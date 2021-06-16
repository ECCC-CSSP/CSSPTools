/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
