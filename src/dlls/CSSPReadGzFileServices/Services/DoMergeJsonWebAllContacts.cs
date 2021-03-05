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
        private void DoMergeJsonWebAllContacts(WebAllContacts WebAllContacts, WebAllContacts WebAllContactsLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemAllContactsList
            // -----------------------------------------------------------
            int count = WebAllContacts.TVItemAllContactList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebAllContactsLocal.TVItemAllContactList
                                        where c.TVItemModel.TVItem.TVItemID == WebAllContacts.TVItemAllContactList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebAllContacts.TVItemAllContactList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in WebAllContactsLocal.TVItemAllContactList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                WebAllContacts.TVItemAllContactList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing ContactList
            // -----------------------------------------------------------
            
            count = WebAllContacts.ContactList.Count;
            for (int i = 0; i < count; i++)
            {
                Contact ContactLocal = (from c in WebAllContactsLocal.ContactList
                                        where c.ContactID == WebAllContacts.ContactList[i].ContactID
                                        && c.DBCommand != DBCommandEnum.Original
                                        select c).FirstOrDefault();

                if (ContactLocal != null)
                {
                    WebAllContacts.ContactList[i] = ContactLocal;
                }
            }

            List<Contact> ContactLocalNewList = (from c in WebAllContactsLocal.ContactList
                                                 where c.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(Contact ContactNew in ContactLocalNewList)
            {
                WebAllContacts.ContactList.Add(ContactNew);
            }

            return;
        }
    }
}
