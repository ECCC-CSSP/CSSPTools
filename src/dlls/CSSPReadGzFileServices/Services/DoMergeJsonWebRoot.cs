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
        private void DoMergeJsonWebRoot(WebRoot WebRoot, WebRoot WebRootLocal)
        {
            if (WebRootLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebRootLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebRootLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebRoot.TVItemModel = WebRootLocal.TVItemModel;
            }

            if ((from c in WebRootLocal.TVItemModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebRoot.TVItemModelParentList = WebRootLocal.TVItemModelParentList;
            }

            List<TVItemModel> TVItemModelList = (from c in WebRootLocal.TVItemModelCountryList
                                                               where c.TVItem.DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (TVItemModel TVItemModel in TVItemModelList)
            {
                TVItemModel TVItemModelOriginal = WebRoot.TVItemModelCountryList.Where(c => c.TVItem.TVItemID == TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelOriginal == null)
                {
                    WebRoot.TVItemModelCountryList.Add(TVItemModelOriginal);
                }
                else
                {
                    TVItemModelOriginal = TVItemModel;
                }
            }

            List<TVFileModel> TVFileModelList = (from c in WebRootLocal.TVFileModelList
                                                 where c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = WebRoot.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    WebRoot.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }
        }
    }
}
