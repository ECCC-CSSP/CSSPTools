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
        private void DoMergeJsonWebPolSourceSites(WebPolSourceSites WebPolSourceSites, WebPolSourceSites WebPolSourceSitesLocal)
        {
            List<PolSourceSiteModel> PolSourceSiteModelList = (from c in WebPolSourceSitesLocal.PolSourceSiteModelList
                                                     where c.PolSourceSite.DBCommand != DBCommandEnum.Original
                                                     select c).ToList();

            foreach (PolSourceSiteModel mwqmRunModel in PolSourceSiteModelList)
            {
                PolSourceSiteModel mwqmRunModelOriginal = WebPolSourceSites.PolSourceSiteModelList.Where(c => c.PolSourceSite.PolSourceSiteID == mwqmRunModel.PolSourceSite.PolSourceSiteID).FirstOrDefault();
                if (mwqmRunModelOriginal == null)
                {
                    WebPolSourceSites.PolSourceSiteModelList.Add(mwqmRunModelOriginal);
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
