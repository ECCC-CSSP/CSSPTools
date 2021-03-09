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
        private void DoMergeJsonWebDrogueRun(WebDrogueRun WebDrogueRun, WebDrogueRun WebDrogueRunLocal)
        {
            // -----------------------------------------------------------
            // doing DrogueRunList
            // -----------------------------------------------------------
            int count = WebDrogueRun.DrogueRunList.Count;
            for (int i = 0; i < count; i++)
            {
                DrogueRun DrogueRunLocal = (from c in WebDrogueRunLocal.DrogueRunList
                                                          where c.DrogueRunID == WebDrogueRun.DrogueRunList[i].DrogueRunID
                                                          && c.DBCommand != DBCommandEnum.Original
                                                          select c).FirstOrDefault();

                if (DrogueRunLocal != null)
                {
                    WebDrogueRun.DrogueRunList[i] = DrogueRunLocal;
                }
            }

            List<DrogueRun> DrogueRunLocalNewList = (from c in WebDrogueRunLocal.DrogueRunList
                                                                   where c.DBCommand == DBCommandEnum.Created
                                                                   select c).ToList();

            foreach (DrogueRun DrogueRunNew in DrogueRunLocalNewList)
            {
                WebDrogueRun.DrogueRunList.Add(DrogueRunNew);
            }

            return;
        }
    }
}
