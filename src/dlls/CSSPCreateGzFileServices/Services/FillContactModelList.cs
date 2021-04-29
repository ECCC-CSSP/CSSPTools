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
        private async Task FillContactModelList(List<ContactModel> ContactModelList, TVItem TVItem)
        {
            List<Contact> ContactList = await GetAllContact();
            List<TVItem> TVItemContactList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.Contact);
            List<TVItemLanguage> TVItemLanguageContactList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.Contact);

            List<TVItem> TVItemEmailList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.Email);
            List<TVItemLanguage> TVItemLanguageEmailList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.Email);

            List<TVItem> TVItemTelList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.Tel);
            List<TVItemLanguage> TVItemLanguageTelList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.Tel);

            List<TVItem> TVItemAddressList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.Address);
            List<TVItemLanguage> TVItemLanguageAddressList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.Address);

            List<Email> EmailList = await GetAllEmail();
            List<Tel> TelList = await GetAllTel();
            List<Address> AddressList = await GetAllAddress();

            List<TVItemLink> TVItemLinkContactEmailList = await GetAllTVItemLink(TVTypeEnum.Contact, TVTypeEnum.Email);
            List<TVItemLink> TVItemLinkContactTelList = await GetAllTVItemLink(TVTypeEnum.Contact, TVTypeEnum.Tel);
            List<TVItemLink> TVItemLinkContactAddressList = await GetAllTVItemLink(TVTypeEnum.Contact, TVTypeEnum.Address);

            foreach (TVItem tvItem in TVItemContactList)
            {
                ContactModel contactModel = new ContactModel();
                contactModel.TVItem = tvItem;
                contactModel.TVItemLanguageList = TVItemLanguageContactList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();
                contactModel.Contact = ContactList.Where(c => c.ContactTVItemID == tvItem.TVItemID).FirstOrDefault();

                // doing email
                List<EmailModel> emailModelList = new List<EmailModel>();

                foreach(TVItemLink tvItemLink in TVItemLinkContactEmailList.Where(c => c.FromTVItemID == tvItem.TVItemID))
                {
                    EmailModel emailModel = new EmailModel();
                    emailModel.Email = EmailList.Where(c => c.EmailTVItemID == tvItemLink.ToTVItemID).FirstOrDefault();
                    emailModel.TVItem = TVItemEmailList.Where(c => c.TVItemID == tvItemLink.ToTVItemID).FirstOrDefault();
                    emailModel.TVItemLanguageList = TVItemLanguageEmailList.Where(c => c.TVItemID == tvItemLink.ToTVItemID).ToList();

                    emailModelList.Add(emailModel);
                }

                contactModel.ContactEmailModelList = emailModelList;

                // doing tel
                List<TelModel> telModelList = new List<TelModel>();

                foreach (TVItemLink tvItemLink in TVItemLinkContactTelList.Where(c => c.FromTVItemID == tvItem.TVItemID))
                {
                    TelModel telModel = new TelModel();
                    telModel.Tel = TelList.Where(c => c.TelTVItemID == tvItemLink.ToTVItemID).FirstOrDefault();
                    telModel.TVItem = TVItemTelList.Where(c => c.TVItemID == tvItemLink.ToTVItemID).FirstOrDefault();
                    telModel.TVItemLanguageList = TVItemLanguageTelList.Where(c => c.TVItemID == tvItemLink.ToTVItemID).ToList();

                    telModelList.Add(telModel);
                }

                contactModel.ContactTelModelList = telModelList;

                // doing address
                List<AddressModel> addressModelList = new List<AddressModel>();

                foreach (TVItemLink tvItemLink in TVItemLinkContactAddressList.Where(c => c.FromTVItemID == tvItem.TVItemID))
                {
                    AddressModel addressModel = new AddressModel();
                    addressModel.Address = AddressList.Where(c => c.AddressTVItemID == tvItemLink.ToTVItemID).FirstOrDefault();
                    addressModel.TVItem = TVItemAddressList.Where(c => c.TVItemID == tvItemLink.ToTVItemID).FirstOrDefault();
                    addressModel.TVItemLanguageList = TVItemLanguageAddressList.Where(c => c.TVItemID == tvItemLink.ToTVItemID).ToList();

                    addressModelList.Add(addressModel);
                }

                contactModel.ContactAddressModelList = addressModelList;

                ContactModelList.Add(contactModel);
            }
        }
    }
}