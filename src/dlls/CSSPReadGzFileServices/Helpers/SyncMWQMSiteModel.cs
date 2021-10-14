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

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void SyncMWQMSiteModel(MWQMSiteModel mwqmSiteModelOriginal, MWQMSiteModel mwqmSiteModelLocal)
        {
            if (mwqmSiteModelLocal != null)
            {
                if (mwqmSiteModelLocal.TVItemModel != null)
                {
                    SyncTVItemModel(mwqmSiteModelOriginal.TVItemModel, mwqmSiteModelLocal.TVItemModel);
                }

                if (mwqmSiteModelLocal.MWQMSite != null)
                {
                    mwqmSiteModelOriginal.MWQMSite = mwqmSiteModelLocal.MWQMSite;
                }
                
                foreach (MWQMSiteStartEndDate mwqmSiteStartEndDate in mwqmSiteModelLocal.MWQMSiteStartEndDateList)
                {
                    MWQMSiteStartEndDate mwqmSiteStartEndDateOriginal = mwqmSiteModelLocal.MWQMSiteStartEndDateList.Where(c => c.MWQMSiteStartEndDateID == mwqmSiteStartEndDate.MWQMSiteStartEndDateID).FirstOrDefault();
                    if (mwqmSiteStartEndDateOriginal == null)
                    {
                        mwqmSiteModelLocal.MWQMSiteStartEndDateList.Add(mwqmSiteStartEndDate);
                    }
                    else
                    {
                        mwqmSiteStartEndDateOriginal = mwqmSiteStartEndDate;
                    }
                }

                List<TVFileModel> TVFileModelList = (from c in mwqmSiteModelLocal.TVFileModelList
                                                     where c.TVItem.TVItemID != 0
                                                     && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                     || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                     || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                     select c).ToList();

                foreach (TVFileModel tvFileModel in TVFileModelList)
                {
                    TVFileModel tvFileModelOriginal = mwqmSiteModelLocal.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                    if (tvFileModelOriginal == null)
                    {
                        mwqmSiteModelLocal.TVFileModelList.Add(tvFileModel);
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
