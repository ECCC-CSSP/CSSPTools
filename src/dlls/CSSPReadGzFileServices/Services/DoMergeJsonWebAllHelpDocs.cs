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
            List<HelpDoc> helpDocLocalList = (from c in WebAllHelpDocsLocal.HelpDocList
                                                    where c.DBCommand != DBCommandEnum.Original
                                                    select c).ToList();

            foreach (HelpDoc helpDocLocal in helpDocLocalList)
            {
                HelpDoc helpDocOriginal = WebAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == helpDocLocal.HelpDocID).FirstOrDefault();
                if (helpDocOriginal == null)
                {
                    WebAllHelpDocs.HelpDocList.Add(helpDocLocal);
                }
                else
                {
                    helpDocOriginal = helpDocLocal;
                }
            }
        }
    }
}
