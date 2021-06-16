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
        private void DoMergeJsonWebProvince(WebProvince WebProvince, WebProvince WebProvinceLocal)
        {
            if (WebProvinceLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebProvinceLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebProvinceLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebProvince.TVItemModel = WebProvinceLocal.TVItemModel;
            }

            if ((from c in WebProvinceLocal.TVItemModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebProvince.TVItemModelParentList = WebProvinceLocal.TVItemModelParentList;
            }

            List<TVItemModel> TVItemModelList = (from c in WebProvinceLocal.TVItemModelAreaList
                                                               where c.TVItem.DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (TVItemModel TVItemModel in TVItemModelList)
            {
                TVItemModel TVItemModelOriginal = WebProvince.TVItemModelAreaList.Where(c => c.TVItem.TVItemID == TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelOriginal == null)
                {
                    WebProvince.TVItemModelAreaList.Add(TVItemModelOriginal);
                }
                else
                {
                    TVItemModelOriginal = TVItemModel;
                }
            }

            List<TVFileModel> TVFileModelList = (from c in WebProvinceLocal.TVFileModelList
                                                 where c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = WebProvince.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    WebProvince.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }
        }
    }
}
