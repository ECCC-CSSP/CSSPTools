/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillChildListTVItemContactModelList(List<ContactModel> ContactModelList, TVItem TVItem)
        {
            List<Contact> MunicipalityContactList = await GetMunicipalityContactListUnderMunicipality(TVItem);
            List<int> MunicipalityContactEmailTVItemIDList = await GetMunicipalityContactEmailTVItemIDListUnderMunicipality(TVItem);
            List<int> MunicipalityContactTelTVItemIDList = await GetMunicipalityContactTelTVItemIDListUnderMunicipality(TVItem);
            List<int> MunicipalityContactAddressTVItemIDList = await GetMunicipalityContactAddressTVItemIDListUnderMunicipality(TVItem);


            foreach (Contact Contact in MunicipalityContactList)
            {
                ContactModel ContactModel = new ContactModel();
                ContactModel.Contact = Contact;
                ContactModel.ContactAddressTVItemIDList = MunicipalityContactAddressTVItemIDList;
                ContactModel.ContactEmailTVItemIDList = MunicipalityContactEmailTVItemIDList;
                ContactModel.ContactTelTVItemIDList = MunicipalityContactTelTVItemIDList;

                ContactModelList.Add(ContactModel);
            }
        }
    }
}