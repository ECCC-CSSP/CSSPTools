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
        private void DoMergeJsonWebClimateSites(WebClimateSites WebClimateSites, WebClimateSites WebClimateSitesLocal)
        {
            if (WebClimateSitesLocal.TVItemStatMapModel.TVItem.DBCommand != DBCommandEnum.Original
                || WebClimateSitesLocal.TVItemStatMapModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                || WebClimateSitesLocal.TVItemStatMapModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebClimateSites.TVItemStatMapModel = WebClimateSitesLocal.TVItemStatMapModel;
            }

            if ((from c in WebClimateSitesLocal.TVItemStatModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebClimateSites.TVItemStatModelParentList = WebClimateSitesLocal.TVItemStatModelParentList;
            }

            List<ClimateSiteModel> ClimateSiteModelList = (from c in WebClimateSitesLocal.ClimateSiteModelList
                                                           where c.ClimateSite.DBCommand != DBCommandEnum.Original
                                                           || (from d in c.ClimateDataValueList
                                                               where d.DBCommand != DBCommandEnum.Original
                                                               select d).Any()
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
