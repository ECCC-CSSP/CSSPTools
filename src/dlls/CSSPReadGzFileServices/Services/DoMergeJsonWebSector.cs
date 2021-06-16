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
        private void DoMergeJsonWebSector(WebSector WebSector, WebSector WebSectorLocal)
        {
            if (WebSectorLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebSectorLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebSectorLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebSector.TVItemModel = WebSectorLocal.TVItemModel;
            }

            if ((from c in WebSectorLocal.TVItemModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebSector.TVItemModelParentList = WebSectorLocal.TVItemModelParentList;
            }

            List<TVItemModel> TVItemModelList = (from c in WebSectorLocal.TVItemModelSubsectorList
                                                               where c.TVItem.DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (TVItemModel TVItemModel in TVItemModelList)
            {
                TVItemModel TVItemModelOriginal = WebSector.TVItemModelSubsectorList.Where(c => c.TVItem.TVItemID == TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelOriginal == null)
                {
                    WebSector.TVItemModelSubsectorList.Add(TVItemModelOriginal);
                }
                else
                {
                    TVItemModelOriginal = TVItemModel;
                }
            }

            List<TVFileModel> TVFileModelList = (from c in WebSectorLocal.TVFileModelList
                                                 where c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = WebSector.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    WebSector.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }
        }
    }
}
