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
        private void DoMergeJsonWebMunicipality(WebMunicipality WebMunicipality, WebMunicipality WebMunicipalityLocal)
        {
            if (WebMunicipalityLocal.TVItemModel.TVItem.TVItemID != 0
                && (WebMunicipalityLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
              || WebMunicipalityLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
              || WebMunicipalityLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                WebMunicipality.TVItemModel = WebMunicipalityLocal.TVItemModel;
            }

            if ((from c in WebMunicipalityLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0 
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                WebMunicipality.TVItemModelParentList = WebMunicipalityLocal.TVItemModelParentList;
            }

            List<ContactModel> ContactModelList = (from c in WebMunicipalityLocal.MunicipalityContactModelList
                                                   where c.TVItemModel.TVItem.TVItemID != 0
                                                   && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                   || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                   || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                   select c).ToList();

            foreach (ContactModel contactModel in ContactModelList)
            {
                ContactModel contactModelOriginal = WebMunicipality.MunicipalityContactModelList.Where(c => c.TVItemModel.TVItem.TVItemID == contactModel.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (contactModelOriginal == null)
                {
                    WebMunicipality.MunicipalityContactModelList.Add(contactModelOriginal);
                }
                else
                {
                    contactModelOriginal = contactModel;
                }
            }

            List<TVFileModel> TVFileModelList = (from c in WebMunicipalityLocal.TVFileModelList
                                                 where c.TVItem.TVItemID != 0
                                                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = WebMunicipality.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    WebMunicipality.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }

            // checking if files are localized
            if (true)
            {
                DirectoryInfo di = new DirectoryInfo($"{CSSPFilesPath}{WebMunicipality.TVItemModel.TVItem.TVItemID}\\");

                if (di.Exists)
                {
                    List<FileInfo> FileInfoList = di.GetFiles().ToList();

                    foreach (TVFileModel tvFileModel in WebMunicipality.TVFileModelList)
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

            // checking if files are localized
            foreach (InfrastructureModel infrastructureModel in WebMunicipality.InfrastructureModelList)
            {
                DirectoryInfo di = new DirectoryInfo($"{CSSPFilesPath}{infrastructureModel.TVItemModel.TVItem.TVItemID}\\");

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
