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

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task FillChildListTVItemContactModelListLocal(List<ContactModel> ContactModelList, TVItem TVItem)
        {
            List<Contact> MunicipalityContactList = await GetMunicipalityContactListUnderMunicipality(TVItem);
            List<Email> MunicipalityContactEmailList = await GetMunicipalityContactEmailListUnderMunicipality(TVItem);
            List<Tel> MunicipalityContactTelList = await GetMunicipalityContactTelListUnderMunicipality(TVItem);
            List<Address> MunicipalityContactAddressList = await GetMunicipalityContactAddressListUnderMunicipality(TVItem);

            foreach (Contact Contact in MunicipalityContactList)
            {
                TVItem TVItemContact = await GetTVItemWithTVItemID(Contact.ContactTVItemID);
                List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItem.TVItemID);

                ContactModel ContactModel = new ContactModel();
                ContactModel.TVItemModel.TVItem = TVItemContact;
                ContactModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                List<EmailModel> EmailModelList = new List<EmailModel>();

                foreach (Email Email in MunicipalityContactEmailList)
                {
                    TVItem TVItemEmail = await GetTVItemWithTVItemID(Email.EmailTVItemID);
                    List<TVItemLanguage> TVItemLanguageEmailList = await GetTVItemLanguageListWithTVItemID(TVItemEmail.TVItemID);

                    EmailModel EmailModel = new EmailModel();
                    EmailModel.TVItemModel.TVItem = TVItemEmail;
                    EmailModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                    {
                        TVItemLanguageEmailList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                        TVItemLanguageEmailList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                        TVItemLanguageEmailList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault()
                    };

                    ContactModel.ContactEmailModelList.Add(EmailModel);
                }

                List<TelModel> TelModelList = new List<TelModel>();

                foreach (Tel Tel in MunicipalityContactTelList)
                {
                    TVItem TVItemTel = await GetTVItemWithTVItemID(Tel.TelTVItemID);
                    List<TVItemLanguage> TVItemLanguageTelList = await GetTVItemLanguageListWithTVItemID(TVItemTel.TVItemID);

                    TelModel TelModel = new TelModel();
                    TelModel.TVItemModel.TVItem = TVItemTel;
                    TelModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                    {
                        TVItemLanguageTelList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                        TVItemLanguageTelList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                        TVItemLanguageTelList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault()
                    };

                    ContactModel.ContactTelModelList.Add(TelModel);
                }

                List<AddressModel> AddressModelList = new List<AddressModel>();

                foreach (Address Address in MunicipalityContactAddressList)
                {
                    TVItem TVItemAddress = await GetTVItemWithTVItemID(Address.AddressTVItemID);
                    List<TVItemLanguage> TVItemLanguageAddressList = await GetTVItemLanguageListWithTVItemID(TVItemAddress.TVItemID);

                    AddressModel AddressModel = new AddressModel();
                    AddressModel.TVItemModel.TVItem = TVItemAddress;
                    AddressModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                    {
                        TVItemLanguageAddressList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                        TVItemLanguageAddressList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                        TVItemLanguageAddressList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault()
                    };

                    ContactModel.ContactAddressModelList.Add(AddressModel);
                }

                ContactModelList.Add(ContactModel);
            }
        }
    }
}