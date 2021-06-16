/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebMunicipality(WebMunicipality WebMunicipality, WebMunicipality WebMunicipalityLocal)
        {
            if (WebMunicipalityLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
              || WebMunicipalityLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
              || WebMunicipalityLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebMunicipality.TVItemModel = WebMunicipalityLocal.TVItemModel;
            }

            if ((from c in WebMunicipalityLocal.TVItemModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebMunicipality.TVItemModelParentList = WebMunicipalityLocal.TVItemModelParentList;
            }

            List<ContactModel> ContactModelList = (from c in WebMunicipalityLocal.MunicipalityContactModelList
                                                   where c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                   || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                   || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
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
