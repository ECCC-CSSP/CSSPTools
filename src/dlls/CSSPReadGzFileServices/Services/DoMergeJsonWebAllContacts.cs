﻿/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllContacts(WebAllContacts WebAllContacts, WebAllContacts WebAllContactsLocal)
        {
            List<ContactModel> contactModelLocalList = (from c in WebAllContactsLocal.ContactModelList
                                                        where c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                        || c.Contact.DBCommand != DBCommandEnum.Original
                                                        select c).ToList();

            foreach (ContactModel contactModelLocal in contactModelLocalList)
            {
                ContactModel contactModelOriginal = WebAllContacts.ContactModelList.Where(c => c.TVItemModel.TVItem.TVItemID == contactModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
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
