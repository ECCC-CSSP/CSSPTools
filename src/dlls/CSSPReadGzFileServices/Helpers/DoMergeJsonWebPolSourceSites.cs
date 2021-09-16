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
using System.Reflection;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebPolSourceSites(WebPolSourceSites WebPolSourceSites, WebPolSourceSites WebPolSourceSitesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebPolSourceSites WebPolSourceSites, WebPolSourceSites WebPolSourceSitesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            List<PolSourceSiteModel> PolSourceSiteModelList = (from c in WebPolSourceSitesLocal.PolSourceSiteModelList
                                                     where c.PolSourceSite.PolSourceSiteID != 0
                                                     && c.PolSourceSite.DBCommand != DBCommandEnum.Original
                                                     select c).ToList();

            foreach (PolSourceSiteModel mwqmPolSourceSiteModel in PolSourceSiteModelList)
            {
                PolSourceSiteModel mwqmPolSourceSiteModelOriginal = WebPolSourceSites.PolSourceSiteModelList.Where(c => c.PolSourceSite.PolSourceSiteID == mwqmPolSourceSiteModel.PolSourceSite.PolSourceSiteID).FirstOrDefault();
                if (mwqmPolSourceSiteModelOriginal == null)
                {
                    WebPolSourceSites.PolSourceSiteModelList.Add(mwqmPolSourceSiteModelOriginal);
                }
                else
                {
                    mwqmPolSourceSiteModelOriginal = mwqmPolSourceSiteModel;
                }

                List<TVFileModel> TVFileModelList = (from c in mwqmPolSourceSiteModel.TVFileModelList
                                                     where c.TVItem.TVItemID != 0
                                                     && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                     || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                     || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                     select c).ToList();

                foreach (TVFileModel tvFileModel in TVFileModelList)
                {
                    TVFileModel tvFileModelOriginal = mwqmPolSourceSiteModel.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                    if (tvFileModelOriginal == null)
                    {
                        mwqmPolSourceSiteModel.TVFileModelList.Add(tvFileModel);
                    }
                    else
                    {
                        tvFileModelOriginal = tvFileModel;
                    }
                }
            }

            foreach (PolSourceSiteModel mwqmPolSourceSiteModel in WebPolSourceSites.PolSourceSiteModelList)
            {
                // checking if files are localized
                DirectoryInfo di = new DirectoryInfo($"{ config.CSSPFilesPath }{ mwqmPolSourceSiteModel.TVItemModel.TVItem.TVItemID }\\");

                if (di.Exists)
                {
                    List<FileInfo> FileInfoList = di.GetFiles().ToList();

                    foreach (TVFileModel tvFileModel in mwqmPolSourceSiteModel.TVFileModelList)
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

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
