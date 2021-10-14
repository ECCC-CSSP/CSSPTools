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

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebMunicipality(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebMunicipality WebMunicipality, WebMunicipality WebMunicipalityLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebMunicipalityTVItemModel(webMunicipality, webMunicipalityLocal);

            DoMergeJsonWebMunicipalityTVItemModelParentList(webMunicipality, webMunicipalityLocal);

            DoMergeJsonWebMunicipalityTVItemModelInfrastructureList(webMunicipality, webMunicipalityLocal);

            DoMergeJsonWebMunicipalityTVItemModelMikeScenarioList(webMunicipality, webMunicipalityLocal);

            DoMergeJsonWebMunicipalityTVFileModelList(webMunicipality, webMunicipalityLocal);

            DoMergeJsonWebMunicipalityMunicipalityIsLocalized(webMunicipality, webMunicipalityLocal);

            DoMergeJsonWebMunicipalityMunicipalityContactModelList(webMunicipality, webMunicipalityLocal);

            DoMergeJsonWebMunicipalityMunicipalityTVItemLinkList(webMunicipality, webMunicipalityLocal);

            DoMergeJsonWebMunicipalityInfrastructureModelList(webMunicipality, webMunicipalityLocal);

            DoMergeJsonWebMunicipalityInfrastructureIsLocalized(webMunicipality, webMunicipalityLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebMunicipalityTVItemModel(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            if (webMunicipalityLocal.TVItemModel.TVItem.TVItemID != 0
                && (webMunicipalityLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
              || webMunicipalityLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
              || webMunicipalityLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webMunicipality.TVItemModel, webMunicipalityLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebMunicipalityTVItemModelParentList(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            if ((from c in webMunicipalityLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webMunicipality.TVItemModelParentList, webMunicipalityLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebMunicipalityTVItemModelInfrastructureList(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            List<TVItemModel> TVItemModelInfrastructureLocalList = (from c in webMunicipalityLocal.TVItemModelInfrastructureList
                                                                    where c.TVItem.TVItemID != 0
                                                                    && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                                    || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                                    || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                                    select c).ToList();

            foreach (TVItemModel TVItemModelInfrastructureLocal in TVItemModelInfrastructureLocalList)
            {
                TVItemModel TVItemModelInfrastructureOriginal = webMunicipality.TVItemModelInfrastructureList.Where(c => c.TVItem.TVItemID == TVItemModelInfrastructureLocal.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelInfrastructureOriginal == null)
                {
                    webMunicipality.TVItemModelInfrastructureList.Add(TVItemModelInfrastructureLocal);
                }
                else
                {
                    SyncTVItemModel(TVItemModelInfrastructureOriginal, TVItemModelInfrastructureLocal);
                }
            }
        }
        private void DoMergeJsonWebMunicipalityTVItemModelMikeScenarioList(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            List<TVItemModel> TVItemModelMikeScenarioLocalList = (from c in webMunicipalityLocal.TVItemModelMikeScenarioList
                                                                  where c.TVItem.TVItemID != 0
                                                                  && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                                  || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                                  || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                                  select c).ToList();

            foreach (TVItemModel TVItemModelMikeScenarioLocal in TVItemModelMikeScenarioLocalList)
            {
                TVItemModel TVItemModelMikeScenarioOriginal = webMunicipality.TVItemModelMikeScenarioList.Where(c => c.TVItem.TVItemID == TVItemModelMikeScenarioLocal.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelMikeScenarioOriginal == null)
                {
                    webMunicipality.TVItemModelMikeScenarioList.Add(TVItemModelMikeScenarioLocal);
                }
                else
                {
                    SyncTVItemModel(TVItemModelMikeScenarioOriginal, TVItemModelMikeScenarioLocal);
                }
            }
        }
        private void DoMergeJsonWebMunicipalityTVFileModelList(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            List<TVFileModel> TVFileModelLocalList = (from c in webMunicipalityLocal.TVFileModelList
                                                      where c.TVItem.TVItemID != 0
                                                      && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                      select c).ToList();

            foreach (TVFileModel tvFileModelLocal in TVFileModelLocalList)
            {
                TVFileModel tvFileModelOriginal = webMunicipality.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    webMunicipality.TVFileModelList.Add(tvFileModelLocal);
                }
                else
                {
                    SyncTVFileModel(tvFileModelOriginal, tvFileModelLocal);
                }
            }
        }
        private void DoMergeJsonWebMunicipalityMunicipalityIsLocalized(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ webMunicipality.TVItemModel.TVItem.TVItemID }\\");

            if (di.Exists)
            {
                List<FileInfo> FileInfoList = di.GetFiles().ToList();

                foreach (TVFileModel tvFileModel in webMunicipality.TVFileModelList)
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
        private void DoMergeJsonWebMunicipalityMunicipalityContactModelList(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            List<ContactModel> ContactModelLocalList = (from c in webMunicipalityLocal.MunicipalityContactModelList
                                                        where c.TVItemModel.TVItem.TVItemID != 0
                                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                        select c).ToList();

            foreach (ContactModel contactModelLocal in ContactModelLocalList)
            {
                ContactModel contactModelOriginal = webMunicipality.MunicipalityContactModelList.Where(c => c.TVItemModel.TVItem.TVItemID == contactModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (contactModelOriginal == null)
                {
                    webMunicipality.MunicipalityContactModelList.Add(contactModelLocal);
                }
                else
                {
                    SyncContactModel(contactModelOriginal, contactModelLocal);
                }
            }
        }
        private void DoMergeJsonWebMunicipalityMunicipalityTVItemLinkList(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            List<TVItemLink> TVItemLinkLocalList = (from c in webMunicipalityLocal.MunicipalityTVItemLinkList
                                                    where c.TVItemLinkID != 0
                                                    && (c.DBCommand != DBCommandEnum.Original)
                                                    select c).ToList();

            foreach (TVItemLink tvItemLinkLocal in TVItemLinkLocalList)
            {
                TVItemLink tvItemLinkOriginal = webMunicipality.MunicipalityTVItemLinkList.Where(c => c.TVItemLinkID == tvItemLinkLocal.TVItemLinkID).FirstOrDefault();
                if (tvItemLinkOriginal == null)
                {
                    webMunicipality.MunicipalityTVItemLinkList.Add(tvItemLinkLocal);
                }
                else
                {
                    tvItemLinkOriginal = tvItemLinkLocal;
                }
            }
        }
        private void DoMergeJsonWebMunicipalityInfrastructureModelList(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            List<InfrastructureModel> InfrastructureModelLocalList = (from c in webMunicipalityLocal.InfrastructureModelList
                                                                 where c.Infrastructure != null
                                                                 && c.Infrastructure.InfrastructureID != 0
                                                                 && (c.Infrastructure.DBCommand != DBCommandEnum.Original)
                                                                 select c).ToList();

            foreach (InfrastructureModel infrastructureModelLocal in InfrastructureModelLocalList)
            {
                InfrastructureModel infrastructureModelOriginal = webMunicipality.InfrastructureModelList.Where(c => c.Infrastructure.InfrastructureID == infrastructureModelLocal.Infrastructure.InfrastructureID).FirstOrDefault();
                if (infrastructureModelOriginal == null)
                {
                    webMunicipality.InfrastructureModelList.Add(infrastructureModelLocal);
                }
                else
                {
                    SyncInfrastructureModel(infrastructureModelOriginal, infrastructureModelLocal);
                }
            }
        }
        private void DoMergeJsonWebMunicipalityInfrastructureIsLocalized(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            foreach (InfrastructureModel infrastructureModel in webMunicipality.InfrastructureModelList)
            {
                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ infrastructureModel.TVItemModel.TVItem.TVItemID }\\");

                if (di.Exists)
                {
                    List<FileInfo> FileInfoList = di.GetFiles().ToList();

                    foreach (TVFileModel tvFileModel in infrastructureModel.TVFileModelList)
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
