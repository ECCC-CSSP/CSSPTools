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
            List<Email> MunicipalityContactEmailList = await GetMunicipalityContactEmailListUnderMunicipality(TVItem);
            List<Tel> MunicipalityContactTelList = await GetMunicipalityContactTelListUnderMunicipality(TVItem);
            List<Address> MunicipalityContactAddressList = await GetMunicipalityContactAddressListUnderMunicipality(TVItem);

            foreach (Contact Contact in MunicipalityContactList)
            {
                ContactModel ContactModel = new ContactModel();
                ContactModel.Contact = Contact;

                foreach (Email Email in MunicipalityContactEmailList)
                {
                    EmailModel EmailModel = new EmailModel();
                    EmailModel.Email = Email;

                    ContactModel.ContactEmailModelList.Add(EmailModel);
                }

                foreach (Tel Tel in MunicipalityContactTelList)
                {
                    TelModel TelModel = new TelModel();
                    TelModel.Tel = Tel;

                    ContactModel.ContactTelModelList.Add(TelModel);
                }

                foreach (Address Address in MunicipalityContactAddressList)
                {
                    AddressModel AddressModel = new AddressModel();
                    AddressModel.Address = Address;

                    ContactModel.ContactAddressModelList.Add(AddressModel);
                }

                ContactModelList.Add(ContactModel);
            }
        }
    }
}