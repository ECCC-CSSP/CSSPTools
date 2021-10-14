/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebCountry(WebCountry webCountry, WebCountry webCountryLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebCountry WebCountry, WebCountry WebCountryLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebCountryTVItemModel(webCountry, webCountryLocal);

            DoMergeJsonWebCountryTVItemModelParentList(webCountry, webCountryLocal);

            DoMergeJsonWebCountryTVItemModelProvinceList(webCountry, webCountryLocal);

            DoMergeJsonWebCountryTVFileModelList(webCountry, webCountryLocal);

            DoMergeJsonWebCountryIsLocalized(webCountry, webCountryLocal);

            DoMergeJsonWebCountryRainExceedanceModelList(webCountry, webCountryLocal);

            DoMergeJsonWebCountryEmailDistributionListModelList(webCountry, webCountryLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebCountryTVItemModel(WebCountry webCountry, WebCountry webCountryLocal)
        {
            if (webCountryLocal.TVItemModel.TVItem.TVItemID != 0
                && (webCountryLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || webCountryLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || webCountryLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webCountry.TVItemModel, webCountryLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebCountryTVItemModelParentList(WebCountry webCountry, WebCountry webCountryLocal)
        {
            if ((from c in webCountryLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webCountry.TVItemModelParentList, webCountryLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebCountryTVItemModelProvinceList(WebCountry webCountry, WebCountry webCountryLocal)
        {
            List<TVItemModel> TVItemModelList = (from c in webCountryLocal.TVItemModelProvinceList
                                                 where c.TVItem.TVItemID != 0
                                                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                 select c).ToList();

            foreach (TVItemModel TVItemModelLocal in TVItemModelList)
            {
                TVItemModel TVItemModelOriginal = webCountry.TVItemModelProvinceList.Where(c => c.TVItem.TVItemID == TVItemModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelOriginal == null)
                {
                    webCountry.TVItemModelProvinceList.Add(TVItemModelLocal);
                }
                else
                {
                    SyncTVItemModel(TVItemModelOriginal, TVItemModelLocal);
                }
            }
        }
        private void DoMergeJsonWebCountryTVFileModelList(WebCountry webCountry, WebCountry webCountryLocal)
        {
            List<TVFileModel> TVFileModelLocalList = (from c in webCountryLocal.TVFileModelList
                                                 where c.TVItem.TVItemID != 0
                                                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                 select c).ToList();

            foreach (TVFileModel tvFileModelLocal in TVFileModelLocalList)
            {
                TVFileModel tvFileModelOriginal = webCountry.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    webCountry.TVFileModelList.Add(tvFileModelLocal);
                }
                else
                {
                    SyncTVFileModel(tvFileModelOriginal, tvFileModelLocal);
                }
            }
        }
        private void DoMergeJsonWebCountryIsLocalized(WebCountry webCountry, WebCountry webCountryLocal)
        {
            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ webCountry.TVItemModel.TVItem.TVItemID }\\");

            if (di.Exists)
            {
                List<FileInfo> FileInfoList = di.GetFiles().ToList();

                foreach (TVFileModel tvFileModel in webCountry.TVFileModelList)
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
        private void DoMergeJsonWebCountryRainExceedanceModelList(WebCountry webCountry, WebCountry webCountryLocal)
        {
            List<RainExceedanceModel> RainExceedanceModelLocalList = (from c in webCountryLocal.RainExceedanceModelList
                                                                 where c.TVItemModel.TVItem.TVItemID != 0
                                                                 && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                                 || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                                 || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                                 select c).ToList();

            foreach (RainExceedanceModel rainExceedanceModelLocal in RainExceedanceModelLocalList)
            {
                RainExceedanceModel rainExceedanceModelOriginal = webCountry.RainExceedanceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == rainExceedanceModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (rainExceedanceModelOriginal == null)
                {
                    webCountry.RainExceedanceModelList.Add(rainExceedanceModelLocal);
                }
                else
                {
                    SyncRainExceedanceModel(rainExceedanceModelOriginal, rainExceedanceModelLocal);
                }
            }
        }
        private void DoMergeJsonWebCountryEmailDistributionListModelList(WebCountry webCountry, WebCountry webCountryLocal)
        {
            List<EmailDistributionListModel> EmailDistributionListModelList = (from c in webCountryLocal.EmailDistributionListModelList
                                                                               where c.EmailDistributionList.EmailDistributionListID != 0
                                                                               && (c.EmailDistributionList.DBCommand != DBCommandEnum.Original)
                                                                               select c).ToList();

            foreach (EmailDistributionListModel emailDistributionListModel in EmailDistributionListModelList)
            {
                EmailDistributionListModel emailDistributionListModelOriginal = webCountry.EmailDistributionListModelList.Where(c => c.EmailDistributionList.EmailDistributionListID == emailDistributionListModel.EmailDistributionList.EmailDistributionListID).FirstOrDefault();
                if (emailDistributionListModelOriginal == null)
                {
                    webCountry.EmailDistributionListModelList.Add(emailDistributionListModel);
                }
                else
                {
                    SyncEmailDistributionListModel(emailDistributionListModelOriginal, emailDistributionListModel);
                }
            }
        }
    }
}
