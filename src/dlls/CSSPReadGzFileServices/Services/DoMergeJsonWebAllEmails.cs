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
            List<EmailModel> emailModelLocalList = (from c in WebAllEmailsLocal.EmailModelList
                                                        where c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                        select c).ToList();

            foreach (EmailModel emailModelLocal in emailModelLocalList)
            {
                EmailModel emailModelOriginal = WebAllEmails.EmailModelList.Where(c => c.TVItemModel.TVItem.TVItemID == emailModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (emailModelOriginal == null)
                {
                    WebAllEmails.EmailModelList.Add(emailModelLocal);
                }
                else
                {
                    emailModelOriginal = emailModelLocal;
                }
            }
        }
    }
}
