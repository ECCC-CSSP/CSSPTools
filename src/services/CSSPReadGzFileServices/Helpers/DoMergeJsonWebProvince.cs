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

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebProvince(WebProvince webProvince, WebProvince webProvinceLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebProvince WebProvince, WebProvince WebProvinceLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebProvinceTVItemModel(webProvince, webProvinceLocal);

            DoMergeJsonWebProvinceTVItemModelParentList(webProvince, webProvinceLocal);

            DoMergeJsonWebProvinceTVItemModelAreaList(webProvince, webProvinceLocal);

            DoMergeJsonWebProvinceTVItemModelMunicipalityList(webProvince, webProvinceLocal);

            DoMergeJsonWebProvinceTVFileModelList(webProvince, webProvinceLocal);

            DoMergeJsonWebProvinceIsLocalized(webProvince, webProvinceLocal);

            DoMergeJsonWebProvinceSamplingPlanModelList(webProvince, webProvinceLocal);

            DoMergeJsonWebProvinceMunicipalityWithInfrastructureTVItemIDList(webProvince, webProvinceLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebProvinceTVItemModel(WebProvince webProvince, WebProvince webProvinceLocal)
        {
            if (webProvinceLocal.TVItemModel.TVItem.TVItemID != 0
                && (webProvinceLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || webProvinceLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || webProvinceLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webProvince.TVItemModel, webProvinceLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebProvinceTVItemModelParentList(WebProvince webProvince, WebProvince webProvinceLocal)
        {
            if ((from c in webProvinceLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webProvince.TVItemModelParentList, webProvinceLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebProvinceTVItemModelAreaList(WebProvince webProvince, WebProvince webProvinceLocal)
        {
            List<TVItemModel> TVItemModelLocalList = (from c in webProvinceLocal.TVItemModelAreaList
                                                      where c.TVItem.TVItemID != 0
                                                      && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                      select c).ToList();

            foreach (TVItemModel TVItemModelLocal in TVItemModelLocalList)
            {
                TVItemModel tvItemModelOriginal = webProvince.TVItemModelAreaList.Where(c => c.TVItem.TVItemID == TVItemModelLocal.TVItem.TVItemID).FirstOrDefault();

                if (webProvince.TVItemModelAreaList.Where(c => c.TVItem.TVItemID == TVItemModelLocal.TVItem.TVItemID).FirstOrDefault() == null)
                {
                    webProvince.TVItemModelAreaList.Add(TVItemModelLocal);
                }
                else
                {
                    SyncTVItemModel(tvItemModelOriginal, TVItemModelLocal);
                }
            }
        }
        private void DoMergeJsonWebProvinceTVItemModelMunicipalityList(WebProvince webProvince, WebProvince webProvinceLocal)
        {
            List<TVItemModel> TVItemModeLocallList = (from c in webProvinceLocal.TVItemModelMunicipalityList
                                                      where c.TVItem.TVItemID != 0
                                                      && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                      select c).ToList();

            foreach (TVItemModel TVItemModelLocal in TVItemModeLocallList)
            {
                TVItemModel tvItemModelOriginal = webProvince.TVItemModelMunicipalityList.Where(c => c.TVItem.TVItemID == TVItemModelLocal.TVItem.TVItemID).FirstOrDefault();

                if (webProvince.TVItemModelMunicipalityList.Where(c => c.TVItem.TVItemID == TVItemModelLocal.TVItem.TVItemID).FirstOrDefault() == null)
                {
                    webProvince.TVItemModelMunicipalityList.Add(TVItemModelLocal);
                }
                else
                {
                    SyncTVItemModel(tvItemModelOriginal, TVItemModelLocal);
                }
            }
        }
        private void DoMergeJsonWebProvinceTVFileModelList(WebProvince webProvince, WebProvince webProvinceLocal)
        {
            List<TVFileModel> TVFileModelLocalList = (from c in webProvinceLocal.TVFileModelList
                                                      where c.TVFile.TVFileID != 0
                                                      && (c.TVFile.DBCommand != DBCommandEnum.Original
                                                      || c.TVFileLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVFileLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                      select c).ToList();

            foreach (TVFileModel tvFileModelLocal in TVFileModelLocalList)
            {
                TVFileModel tvFileModelOriginal = webProvince.TVFileModelList.Where(c => c.TVFile.TVFileID == tvFileModelLocal.TVFile.TVFileID).FirstOrDefault();

                if (tvFileModelOriginal == null)
                {
                    webProvince.TVFileModelList.Add(tvFileModelLocal);
                }
                else
                {
                    SyncTVFileModel(tvFileModelOriginal, tvFileModelLocal);
                }
            }
        }
        private void DoMergeJsonWebProvinceIsLocalized(WebProvince webProvince, WebProvince webProvinceLocal)
        {
            DirectoryInfo di = new DirectoryInfo($"{Configuration["CSSPFilesPath"] }{ webProvince.TVItemModel.TVItem.TVItemID }\\");

            if (di.Exists)
            {
                List<FileInfo> FileInfoList = di.GetFiles().ToList();

                foreach (TVFileModel tvFileModel in webProvince.TVFileModelList)
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
        private void DoMergeJsonWebProvinceSamplingPlanModelList(WebProvince webProvince, WebProvince webProvinceLocal)
        {
            List<SamplingPlanModel> SamplingPlanModelLocalList = (from c in webProvinceLocal.SamplingPlanModelList
                                                                  where c.SamplingPlan.SamplingPlanID != 0
                                                                  && (c.SamplingPlan.DBCommand != DBCommandEnum.Original)
                                                                  select c).ToList();

            foreach (SamplingPlanModel samplingPlanModelLocal in SamplingPlanModelLocalList)
            {
                SamplingPlanModel samplingPlanModelOriginal = webProvince.SamplingPlanModelList.Where(c => c.SamplingPlan.SamplingPlanID == samplingPlanModelLocal.SamplingPlan.SamplingPlanID).FirstOrDefault();

                if (webProvince.SamplingPlanModelList.Where(c => c.SamplingPlan.SamplingPlanID == samplingPlanModelLocal.SamplingPlan.SamplingPlanID).FirstOrDefault() == null)
                {
                    webProvince.SamplingPlanModelList.Add(samplingPlanModelLocal);
                }
                else
                {
                    SyncSamplingPlanModel(samplingPlanModelOriginal, samplingPlanModelLocal);
                }
            }
        }
        private void DoMergeJsonWebProvinceMunicipalityWithInfrastructureTVItemIDList(WebProvince webProvince, WebProvince webProvinceLocal)
        {
            foreach (int municipalityWithInfrastructureTVItemIDLocal in webProvinceLocal.MunicipalityWithInfrastructureTVItemIDList)
            {
                if (!webProvince.MunicipalityWithInfrastructureTVItemIDList.Where(c => c == municipalityWithInfrastructureTVItemIDLocal).Any())
                {
                    webProvince.MunicipalityWithInfrastructureTVItemIDList.Add(municipalityWithInfrastructureTVItemIDLocal);
                }
            }
        }
    }
}
