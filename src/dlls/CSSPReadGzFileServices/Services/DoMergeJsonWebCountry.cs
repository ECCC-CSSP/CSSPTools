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
        private void DoMergeJsonWebCountry(WebCountry WebCountry, WebCountry WebCountryLocal)
        {
            if (WebCountryLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebCountryLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebCountryLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebCountry.TVItemModel = WebCountryLocal.TVItemModel;
            }

            if ((from c in WebCountryLocal.TVItemModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebCountry.TVItemModelParentList = WebCountryLocal.TVItemModelParentList;
            }

            List<TVItemModel> TVItemModelList = (from c in WebCountryLocal.TVItemModelProvinceList
                                                               where c.TVItem.DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (TVItemModel TVItemModel in TVItemModelList)
            {
                TVItemModel TVItemModelOriginal = WebCountry.TVItemModelProvinceList.Where(c => c.TVItem.TVItemID == TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelOriginal == null)
                {
                    WebCountry.TVItemModelProvinceList.Add(TVItemModelOriginal);
                }
                else
                {
                    TVItemModelOriginal = TVItemModel;
                }
            }

            List<TVFileModel> TVFileModelList = (from c in WebCountryLocal.TVFileModelList
                                                 where c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = WebCountry.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    WebCountry.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }
        }
    }
}
