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
        private void DoMergeJsonWebAllTVItemLanguages(WebAllTVItemLanguages WebAllTVItemLanguages, WebAllTVItemLanguages WebAllTVItemLanguagesLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemLanguageList
            // -----------------------------------------------------------
            
            int count = WebAllTVItemLanguages.TVItemLanguageList.Count;
            for (int i = 0; i < count; i++)
            {
                TVItemLanguage TVItemLanguageLocal = (from c in WebAllTVItemLanguagesLocal.TVItemLanguageList
                                        where c.TVItemLanguageID == WebAllTVItemLanguages.TVItemLanguageList[i].TVItemLanguageID
                                        && c.DBCommand != DBCommandEnum.Original
                                        select c).FirstOrDefault();

                if (TVItemLanguageLocal != null)
                {
                    WebAllTVItemLanguages.TVItemLanguageList[i] = TVItemLanguageLocal;
                }
            }

            List<TVItemLanguage> TVItemLanguageLocalNewList = (from c in WebAllTVItemLanguagesLocal.TVItemLanguageList
                                                 where c.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(TVItemLanguage TVItemLanguageNew in TVItemLanguageLocalNewList)
            {
                WebAllTVItemLanguages.TVItemLanguageList.Add(TVItemLanguageNew);
            }

            return;
        }
    }
}
