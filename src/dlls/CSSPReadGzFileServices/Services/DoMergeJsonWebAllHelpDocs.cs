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
        private void DoMergeJsonWebAllHelpDocs(WebAllHelpDocs WebAllHelpDocs, WebAllHelpDocs WebAllHelpDocsLocal)
        {
            // -----------------------------------------------------------
            // doing HelpDocList
            // -----------------------------------------------------------
            int count = WebAllHelpDocs.HelpDocList.Count;
            for (int i = 0; i < count; i++)
            {
                HelpDoc helpDocLocal = (from c in WebAllHelpDocsLocal.HelpDocList
                                        where c.HelpDocID == WebAllHelpDocs.HelpDocList[i].HelpDocID
                                        && c.DBCommand != DBCommandEnum.Original
                                        select c).FirstOrDefault();

                if (helpDocLocal != null)
                {
                    WebAllHelpDocs.HelpDocList[i] = helpDocLocal;
                }
            }

            List<HelpDoc> helpDocLocalNewList = (from c in WebAllHelpDocsLocal.HelpDocList
                                                 where c.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (HelpDoc helpDocNew in helpDocLocalNewList)
            {
                WebAllHelpDocs.HelpDocList.Add(helpDocNew);
            }

            return;
        }
    }
}
