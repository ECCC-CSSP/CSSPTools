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
        private void DoMergeJsonWebAllTels(WebAllTels WebAllTels, WebAllTels WebAllTelsLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemAllTelsList
            // -----------------------------------------------------------
            int count = WebAllTels.TVItemAllTelList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebAllTelsLocal.TVItemAllTelList
                                        where c.TVItemModel.TVItem.TVItemID == WebAllTels.TVItemAllTelList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebAllTels.TVItemAllTelList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in WebAllTelsLocal.TVItemAllTelList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                WebAllTels.TVItemAllTelList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TelList
            // -----------------------------------------------------------
            
            count = WebAllTels.TelList.Count;
            for (int i = 0; i < count; i++)
            {
                Tel TelLocal = (from c in WebAllTelsLocal.TelList
                                        where c.TelID == WebAllTels.TelList[i].TelID
                                        && c.DBCommand != DBCommandEnum.Original
                                        select c).FirstOrDefault();

                if (TelLocal != null)
                {
                    WebAllTels.TelList[i] = TelLocal;
                }
            }

            List<Tel> TelLocalNewList = (from c in WebAllTelsLocal.TelList
                                                 where c.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(Tel TelNew in TelLocalNewList)
            {
                WebAllTels.TelList.Add(TelNew);
            }

            return;
        }
    }
}
