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
        private void DoMergeJsonWebTideSites(WebTideSites WebTideSites, WebTideSites WebTideSitesLocal)
        {
            if (WebTideSitesLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                || WebTideSitesLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                || WebTideSitesLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebTideSites.TVItemModel = WebTideSitesLocal.TVItemModel;
            }

            if ((from c in WebTideSitesLocal.TVItemModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebTideSites.TVItemModelParentList = WebTideSitesLocal.TVItemModelParentList;
            }

            List<TideSiteModel> TideSiteModelList = (from c in WebTideSitesLocal.TideSiteModelList
                                                           where c.TideSite.DBCommand != DBCommandEnum.Original
                                                           || (from d in c.TideDataValueList
                                                               where d.DBCommand != DBCommandEnum.Original
                                                               select d).Any()
                                                           select c).ToList();

            foreach (TideSiteModel tideSiteModel in TideSiteModelList)
            {
                TideSiteModel tideSiteModelOriginal = WebTideSites.TideSiteModelList.Where(c => c.TideSite.TideSiteID == tideSiteModel.TideSite.TideSiteID).FirstOrDefault();
                if (tideSiteModelOriginal == null)
                {
                    WebTideSites.TideSiteModelList.Add(tideSiteModelOriginal);
                }
                else
                {
                    tideSiteModelOriginal = tideSiteModel;
                }
            }
        }
    }
}
