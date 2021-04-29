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
            List<ContactModel> contactModelLocalList = (from c in WebAllContactsLocal.ContactModelList
                                                        where c.TVItem.DBCommand != DBCommandEnum.Original
                                                        || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                        || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                        || c.Contact.DBCommand != DBCommandEnum.Original
                                                        || (from e in c.ContactEmailModelList
                                                            where e.TVItem.DBCommand != DBCommandEnum.Original
                                                            select e).Any()
                                                        || (from t in c.ContactTelModelList
                                                            where t.TVItem.DBCommand != DBCommandEnum.Original
                                                            select t).Any()
                                                        || (from a in c.ContactAddressModelList
                                                            where a.TVItem.DBCommand != DBCommandEnum.Original
                                                            select a).Any()
                                                        select c).ToList();

            foreach (ContactModel contactModelLocal in contactModelLocalList)
            {
                ContactModel contactModelOriginal = WebAllContacts.ContactModelList.Where(c => c.TVItem.TVItemID == contactModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (contactModelOriginal == null)
                {
                    WebAllContacts.ContactModelList.Add(contactModelLocal);
                }
                else
                {
                    contactModelOriginal = contactModelLocal;
                }
            }
        }
    }
}
