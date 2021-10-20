﻿/*
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
        private async Task<bool> DoMergeJsonWebMunicipality(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebMunicipality WebMunicipality, WebMunicipality WebMunicipalityLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebMunicipalityTVItemModel(webMunicipality, webMunicipalityLocal);

            DoMergeJsonWebMunicipalityTVItemModelParentList(webMunicipality, webMunicipalityLocal);

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
        private void DoMergeJsonWebMunicipalityTVFileModelList(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            List<TVFileModel> TVFileModelLocalList = (from c in webMunicipalityLocal.TVFileModelList
                                                      where c.TVFile.TVFileID != 0
                                                      && (c.TVFile.DBCommand != DBCommandEnum.Original
                                                      || c.TVFileLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVFileLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                      select c).ToList();

            foreach (TVFileModel tvFileModelLocal in TVFileModelLocalList)
            {
                TVFileModel tvFileModelOriginal = webMunicipality.TVFileModelList.Where(c => c.TVFile.TVFileID == tvFileModelLocal.TVFile.TVFileID).FirstOrDefault();
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
                                                        where c.Contact.ContactID != 0
                                                        && c.Contact.DBCommand != DBCommandEnum.Original
                                                        select c).ToList();

            foreach (ContactModel contactModelLocal in ContactModelLocalList)
            {
                ContactModel contactModelOriginal = webMunicipality.MunicipalityContactModelList.Where(c => c.Contact.ContactID == contactModelLocal.Contact.ContactID).FirstOrDefault();
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
            foreach(InfrastructureModel infrastructureModelLocal in webMunicipalityLocal.InfrastructureModelList)
            {
                bool needSync = false;
                if (infrastructureModelLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                    || infrastructureModelLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                    || infrastructureModelLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                {
                    needSync = true;
                }

                if (needSync)
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
            List<InfrastructureModel> InfrastructureModelLocalList = (from c in webMunicipalityLocal.InfrastructureModelList
                                                                 where c.Infrastructure != null
                                                                 && c.TVItemModel.TVItem.TVItemID != 0
                                                                 && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
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

            // more to do
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
