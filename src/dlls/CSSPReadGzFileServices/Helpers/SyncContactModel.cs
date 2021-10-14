/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void SyncContactModel(ContactModel contactModelOriginal, ContactModel contactModelLocal)
        {
            if (contactModelLocal != null)
            {
                if (contactModelLocal.TVItemModel != null)
                {
                    SyncTVItemModel(contactModelOriginal.TVItemModel, contactModelLocal.TVItemModel);
                }
                if (contactModelLocal.Contact != null)
                {
                    contactModelOriginal.Contact = contactModelLocal.Contact;
                }
                if (contactModelLocal.ContactEmailTVItemIDList != null)
                {
                    contactModelOriginal.ContactEmailTVItemIDList = contactModelLocal.ContactEmailTVItemIDList;
                }
                if (contactModelLocal.ContactTelTVItemIDList!= null)
                {
                    contactModelOriginal.ContactTelTVItemIDList = contactModelLocal.ContactTelTVItemIDList;
                }
                if (contactModelLocal.ContactAddressTVItemIDList != null)
                {
                    contactModelOriginal.ContactAddressTVItemIDList = contactModelLocal.ContactAddressTVItemIDList;
                }
            }
        }
    }
}
