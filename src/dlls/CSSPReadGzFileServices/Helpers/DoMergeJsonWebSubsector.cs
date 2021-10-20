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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebSubsector(WebSubsector webSubsector, WebSubsector webSubsectorLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebSubsector WebSubsector, WebSubsector WebSubsectorLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebSubsectorTVItemModel(webSubsector, webSubsectorLocal);

            DoMergeJsonWebSubsectorTVItemModelParentList(webSubsector, webSubsectorLocal);

            DoMergeJsonWebSubsectorTVFileModelList(webSubsector, webSubsectorLocal);

            DoMergeJsonWebSubsectorIsLocalized(webSubsector, webSubsectorLocal);

            DoMergeJsonWebSubsectorTVItemModelClassificationList(webSubsector, webSubsectorLocal);

            DoMergeJsonWebSubsectorMWQMAnalysisReportParameterList(webSubsector, webSubsectorLocal);

            DoMergeJsonWebSubsectorMWQMSubsector(webSubsector, webSubsectorLocal);

            DoMergeJsonWebSubsectorMWQMSubsectorLanguageList(webSubsector, webSubsectorLocal);

            DoMergeJsonWebSubsectorUseOfSiteList(webSubsector, webSubsectorLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebSubsectorTVItemModel(WebSubsector webSubsector, WebSubsector webSubsectorLocal)
        {
            if (webSubsectorLocal.TVItemModel.TVItem.TVItemID != 0
                && (webSubsectorLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || webSubsectorLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || webSubsectorLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webSubsector.TVItemModel, webSubsectorLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebSubsectorTVItemModelParentList(WebSubsector webSubsector, WebSubsector webSubsectorLocal)
        {
            if ((from c in webSubsectorLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webSubsector.TVItemModelParentList, webSubsectorLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebSubsectorTVFileModelList(WebSubsector webSubsector, WebSubsector webSubsectorLocal)
        {
            List<TVFileModel> TVFileModelLocalList = (from c in webSubsectorLocal.TVFileModelList
                                                      where c.TVFile.TVFileID != 0
                                                      && (c.TVFile.DBCommand != DBCommandEnum.Original
                                                      || c.TVFileLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVFileLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                      select c).ToList();

            foreach (TVFileModel tvFileModelLocal in TVFileModelLocalList)
            {
                TVFileModel tvFileModelOriginal = webSubsector.TVFileModelList.Where(c => c.TVFile.TVFileID == tvFileModelLocal.TVFile.TVFileID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    webSubsector.TVFileModelList.Add(tvFileModelLocal);
                }
                else
                {
                    SyncTVFileModel(tvFileModelOriginal, tvFileModelLocal);
                }
            }
        }
        private void DoMergeJsonWebSubsectorIsLocalized(WebSubsector webSubsector, WebSubsector webSubsectorLocal)
        {
            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ webSubsector.TVItemModel.TVItem.TVItemID }\\");

            if (di.Exists)
            {
                List<FileInfo> FileInfoList = di.GetFiles().ToList();

                foreach (TVFileModel tvFileModel in webSubsector.TVFileModelList)
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
        private void DoMergeJsonWebSubsectorTVItemModelClassificationList(WebSubsector webSubsector, WebSubsector webSubsectorLocal)
        {
            List<TVItemModel> TVItemModelLocalList = (from c in webSubsectorLocal.TVItemModelClassificationList
                                                      where c.TVItem.TVItemID != 0
                                                      && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                      select c).ToList();

            foreach (TVItemModel tvItemModelLocal in TVItemModelLocalList)
            {
                TVItemModel tvItemModelOriginal = webSubsector.TVItemModelClassificationList.Where(c => c.TVItem.TVItemID == tvItemModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvItemModelOriginal == null)
                {
                    webSubsector.TVItemModelClassificationList.Add(tvItemModelLocal);
                }
                else
                {
                    SyncTVItemModel(tvItemModelOriginal, tvItemModelLocal);
                }
            }
        }
        private void DoMergeJsonWebSubsectorMWQMAnalysisReportParameterList(WebSubsector webSubsector, WebSubsector webSubsectorLocal)
        {
            List<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterLocalList = (from c in webSubsectorLocal.MWQMAnalysisReportParameterList
                                                                                      where c.SubsectorTVItemID != 0
                                                                                      && c.DBCommand != DBCommandEnum.Original
                                                                                      select c).ToList();

            foreach (MWQMAnalysisReportParameter mwqmAnalysisReportParameterLocal in MWQMAnalysisReportParameterLocalList)
            {
                MWQMAnalysisReportParameter mwqmAnalysisReportParameterOriginal = webSubsector.MWQMAnalysisReportParameterList.Where(c => c.SubsectorTVItemID == mwqmAnalysisReportParameterLocal.SubsectorTVItemID).FirstOrDefault();
                if (mwqmAnalysisReportParameterOriginal == null)
                {
                    webSubsector.MWQMAnalysisReportParameterList.Add(mwqmAnalysisReportParameterLocal);
                }
                else
                {
                    mwqmAnalysisReportParameterOriginal = mwqmAnalysisReportParameterLocal;
                }
            }
        }
        private void DoMergeJsonWebSubsectorMWQMSubsector(WebSubsector webSubsector, WebSubsector webSubsectorLocal)
        {
            if (webSubsectorLocal.MWQMSubsector != null)
            {
                if (webSubsectorLocal.MWQMSubsector.DBCommand != DBCommandEnum.Original)
                {
                    webSubsector.MWQMSubsector = webSubsectorLocal.MWQMSubsector;
                }
            }
        }
        private void DoMergeJsonWebSubsectorMWQMSubsectorLanguageList(WebSubsector webSubsector, WebSubsector webSubsectorLocal)
        {
            if (webSubsectorLocal.MWQMSubsectorLanguageList != null)
            {
                webSubsector.MWQMSubsectorLanguageList = webSubsectorLocal.MWQMSubsectorLanguageList;
            }
        }
        private void DoMergeJsonWebSubsectorUseOfSiteList(WebSubsector webSubsector, WebSubsector webSubsectorLocal)
        {
            List<UseOfSite> UseOfSiteLocalList = (from c in webSubsectorLocal.UseOfSiteList
                                                  where c.SubsectorTVItemID != 0
                                                  && c.DBCommand != DBCommandEnum.Original
                                                  select c).ToList();

            foreach (UseOfSite useOfSiteLocal in UseOfSiteLocalList)
            {
                UseOfSite useOfSiteOriginal = webSubsector.UseOfSiteList.Where(c => c.SubsectorTVItemID == useOfSiteLocal.SubsectorTVItemID).FirstOrDefault();
                if (useOfSiteOriginal == null)
                {
                    webSubsector.UseOfSiteList.Add(useOfSiteLocal);
                }
                else
                {
                    useOfSiteOriginal = useOfSiteLocal;
                }
            }
        }
    }
}
