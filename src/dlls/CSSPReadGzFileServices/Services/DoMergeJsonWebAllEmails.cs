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
        private void DoMergeJsonWebAllEmails(WebAllEmails WebAllEmails, WebAllEmails WebAllEmailsLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemAllEmailsList
            // -----------------------------------------------------------
            int count = WebAllEmails.TVItemAllEmailList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebAllEmailsLocal.TVItemAllEmailList
                                        where c.TVItemModel.TVItem.TVItemID == WebAllEmails.TVItemAllEmailList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebAllEmails.TVItemAllEmailList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in WebAllEmailsLocal.TVItemAllEmailList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                WebAllEmails.TVItemAllEmailList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing EmailList
            // -----------------------------------------------------------
            
            count = WebAllEmails.EmailList.Count;
            for (int i = 0; i < count; i++)
            {
                Email EmailLocal = (from c in WebAllEmailsLocal.EmailList
                                        where c.EmailID == WebAllEmails.EmailList[i].EmailID
                                        && c.DBCommand != DBCommandEnum.Original
                                        select c).FirstOrDefault();

                if (EmailLocal != null)
                {
                    WebAllEmails.EmailList[i] = EmailLocal;
                }
            }

            List<Email> EmailLocalNewList = (from c in WebAllEmailsLocal.EmailList
                                                 where c.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(Email EmailNew in EmailLocalNewList)
            {
                WebAllEmails.EmailList.Add(EmailNew);
            }

            return;
        }
    }
}
