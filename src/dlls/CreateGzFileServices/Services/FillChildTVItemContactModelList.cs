/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillChildTVItemContactModel(List<ContactModel> ContactModelList, TVItem TVItem)
        {
            List<Contact> MunicipalityContactList = await GetMunicipalityContactListUnderMunicipality(TVItem);
            List<Email> MunicipalityContactEmailList = await GetMunicipalityContactEmailListUnderMunicipality(TVItem);
            List<Tel> MunicipalityContactTelList = await GetMunicipalityContactTelListUnderMunicipality(TVItem);
            List<Address> MunicipalityContactAddressList = await GetMunicipalityContactAddressListUnderMunicipality(TVItem);

            foreach (Contact contact in MunicipalityContactList)
            {
                TVItem tvItemContact = await GetTVItemWithTVItemID(contact.ContactTVItemID);
                List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItem.TVItemID);
                
                ContactModel contactModel = new ContactModel();
                contactModel.TVItemModel.TVItem = tvItemContact;
                contactModel.TVItemModel.TVItemLanguageEN = TVItemLanguageList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault();
                contactModel.TVItemModel.TVItemLanguageFR = TVItemLanguageList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault();

                List<EmailModel> emailModelList = new List<EmailModel>();

                foreach (Email email in MunicipalityContactEmailList)
                {
                    TVItem tvItemEmail = await GetTVItemWithTVItemID(email.EmailTVItemID);
                    List<TVItemLanguage> TVItemLanguageEmailList = await GetTVItemLanguageListWithTVItemID(tvItemEmail.TVItemID);

                    EmailModel emailModel = new EmailModel();
                    emailModel.TVItemModel.TVItem = tvItemEmail;
                    emailModel.TVItemModel.TVItemLanguageEN = TVItemLanguageEmailList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault();
                    emailModel.TVItemModel.TVItemLanguageFR = TVItemLanguageEmailList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault();

                    contactModel.ContactEmailModelList.Add(emailModel);
                }

                List<TelModel> telModelList = new List<TelModel>();

                foreach (Tel tel in MunicipalityContactTelList)
                {
                    TVItem tvItemTel = await GetTVItemWithTVItemID(tel.TelTVItemID);
                    List<TVItemLanguage> TVItemLanguageTelList = await GetTVItemLanguageListWithTVItemID(tvItemTel.TVItemID);

                    TelModel telModel = new TelModel();
                    telModel.TVItemModel.TVItem = tvItemTel;
                    telModel.TVItemModel.TVItemLanguageEN = TVItemLanguageTelList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault();
                    telModel.TVItemModel.TVItemLanguageFR = TVItemLanguageTelList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault();

                    contactModel.ContactTelModelList.Add(telModel);
                }

                List<AddressModel> addressModelList = new List<AddressModel>();

                foreach (Address address in MunicipalityContactAddressList)
                {
                    TVItem tvItemAddress = await GetTVItemWithTVItemID(address.AddressTVItemID);
                    List<TVItemLanguage> TVItemLanguageAddressList = await GetTVItemLanguageListWithTVItemID(tvItemAddress.TVItemID);

                    AddressModel addressModel = new AddressModel();
                    addressModel.TVItemModel.TVItem = tvItemAddress;
                    addressModel.TVItemModel.TVItemLanguageEN = TVItemLanguageAddressList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault();
                    addressModel.TVItemModel.TVItemLanguageFR = TVItemLanguageAddressList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault();

                    contactModel.ContactAddressModelList.Add(addressModel);
                }

                ContactModelList.Add(contactModel);
            }
        }
    }
}