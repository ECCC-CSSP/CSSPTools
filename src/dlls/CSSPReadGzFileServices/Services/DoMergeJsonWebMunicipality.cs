/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using LoggedInServices;
using CSSPWebModels;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebMunicipality(WebMunicipality WebMunicipality, WebMunicipality WebMunicipalityLocal)
        {
            if (WebMunicipalityLocal.TVItemStatMapModel.TVItem.DBCommand != DBCommandEnum.Original
              || WebMunicipalityLocal.TVItemStatMapModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
              || WebMunicipalityLocal.TVItemStatMapModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebMunicipality.TVItemStatMapModel = WebMunicipalityLocal.TVItemStatMapModel;
            }

            if ((from c in WebMunicipalityLocal.TVItemStatModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebMunicipality.TVItemStatModelParentList = WebMunicipalityLocal.TVItemStatModelParentList;
            }

            List<ContactModel> ContactModelList = (from c in WebMunicipalityLocal.MunicipalityContactModelList
                                                   where c.TVItem.DBCommand != DBCommandEnum.Original
                                                   || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                   || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                   select c).ToList();

            foreach (ContactModel contactModel in ContactModelList)
            {
                ContactModel contactModelOriginal = WebMunicipality.MunicipalityContactModelList.Where(c => c.TVItem.TVItemID == contactModel.TVItem.TVItemID).FirstOrDefault();
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
                                                 where c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
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
        }
    }
}
