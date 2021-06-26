/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebMWQMSites(WebMWQMSites WebMWQMSites, WebMWQMSites WebMWQMSitesLocal)
        {
            List<MWQMSiteModel> MWQMSiteModelList = (from c in WebMWQMSitesLocal.MWQMSiteModelList
                                                     where c.MWQMSite.MWQMSiteID != 0
                                                     && c.MWQMSite.DBCommand != DBCommandEnum.Original
                                                     select c).ToList();

            foreach (MWQMSiteModel mwqmSiteModel in MWQMSiteModelList)
            {
                MWQMSiteModel mwqmSiteModelOriginal = WebMWQMSites.MWQMSiteModelList.Where(c => c.MWQMSite.MWQMSiteID == mwqmSiteModel.MWQMSite.MWQMSiteID).FirstOrDefault();
                if (mwqmSiteModelOriginal == null)
                {
                    WebMWQMSites.MWQMSiteModelList.Add(mwqmSiteModelOriginal);
                }
                else
                {
                    mwqmSiteModelOriginal = mwqmSiteModel;
                }

                List<TVFileModel> TVFileModelList = (from c in mwqmSiteModel.TVFileModelList
                                                     where c.TVItem.TVItemID != 0
                                                     && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                     || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                     || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                     select c).ToList();

                foreach (TVFileModel tvFileModel in TVFileModelList)
                {
                    TVFileModel tvFileModelOriginal = mwqmSiteModel.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                    if (tvFileModelOriginal == null)
                    {
                        mwqmSiteModel.TVFileModelList.Add(tvFileModel);
                    }
                    else
                    {
                        tvFileModelOriginal = tvFileModel;
                    }
                }             
            }

            foreach (MWQMSiteModel mwqmSiteModel in WebMWQMSites.MWQMSiteModelList)
            {
                // checking if files are localized
                DirectoryInfo di = new DirectoryInfo($"{CSSPFilesPath}{mwqmSiteModel.TVItemModel.TVItem.TVItemID}\\");

                if (di.Exists)
                {
                    List<FileInfo> FileInfoList = di.GetFiles().ToList();

                    foreach (TVFileModel tvFileModel in mwqmSiteModel.TVFileModelList)
                    {
                        if ((from c in FileInfoList
                             where c.Name == tvFileModel.TVFile.ServerFileName
                             select c).Any())
                        {
                            tvFileModel.IsLocalized = true;
                        }
                        else
                        {
                            tvFileModel.IsLocalized = false;
                        }
                    }
                }
            }
        }
    }
}
