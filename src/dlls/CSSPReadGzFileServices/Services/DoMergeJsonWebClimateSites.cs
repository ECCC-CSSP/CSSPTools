﻿/*
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
        private void DoMergeJsonWebClimateSites(WebClimateSites WebClimateSites, WebClimateSites WebClimateSitesLocal)
        {
            if (WebClimateSitesLocal.TVItemModel.TVItem.TVItemID != 0
                && (WebClimateSitesLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                || WebClimateSitesLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                || WebClimateSitesLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                WebClimateSites.TVItemModel = WebClimateSitesLocal.TVItemModel;
            }

            if ((from c in WebClimateSitesLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                WebClimateSites.TVItemModelParentList = WebClimateSitesLocal.TVItemModelParentList;
            }

            List<ClimateSiteModel> ClimateSiteModelList = (from c in WebClimateSitesLocal.ClimateSiteModelList
                                                           where c.TVItemModel.TVItem.TVItemID != 0
                                                           && (c.ClimateSite.DBCommand != DBCommandEnum.Original
                                                           || (from d in c.ClimateDataValueList
                                                               where d.DBCommand != DBCommandEnum.Original
                                                               select d).Any())
                                                           select c).ToList();

            foreach (ClimateSiteModel climateSiteModel in ClimateSiteModelList)
            {
                ClimateSiteModel climateSiteModelOriginal = WebClimateSites.ClimateSiteModelList.Where(c => c.ClimateSite.ClimateSiteID == climateSiteModel.ClimateSite.ClimateSiteID).FirstOrDefault();
                if (climateSiteModelOriginal == null)
                {
                    WebClimateSites.ClimateSiteModelList.Add(climateSiteModelOriginal);
                }
                else
                {
                    climateSiteModelOriginal = climateSiteModel;
                }
            }
        }
    }
}
