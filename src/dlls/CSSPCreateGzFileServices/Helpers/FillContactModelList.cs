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
using System.Text.RegularExpressions;
using System.Reflection;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> FillContactModelList(List<ContactModel> ContactModelList, TVItem TVItem)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<ContactModel> ContactModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
            CSSPLogService.FunctionLog(FunctionName);

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
                TVItemModel tvItemModel = new TVItemModel();
                tvItemModel.TVItem = tvItem;
                tvItemModel.TVItemLanguageList = (from c in TVItemLanguageContactList
                                                  where c.TVItemID == tvItem.TVItemID
                                                  select c).ToList();

                foreach (TVItemLanguage tvItemLanguage in tvItemModel.TVItemLanguageList)
                {
                    tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex("[ ]{2,}", options);
                    tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                }

                ContactModel contactModel = new ContactModel();
                contactModel.Contact = ContactList.Where(c => c.ContactTVItemID == tvItem.TVItemID).FirstOrDefault();
                contactModel.TVItemModel = tvItemModel;

                contactModel.ContactEmailTVItemIDList = (from c in TVItemLinkContactEmailList
                                                         where c.FromTVItemID == tvItem.TVItemID
                                                         select c.ToTVItemID).ToList();

                contactModel.ContactTelTVItemIDList = (from c in TVItemLinkContactTelList
                                                       where c.FromTVItemID == tvItem.TVItemID
                                                       select c.ToTVItemID).ToList();

                contactModel.ContactAddressTVItemIDList = (from c in TVItemLinkContactAddressList
                                                           where c.FromTVItemID == tvItem.TVItemID
                                                           select c.ToTVItemID).ToList();

                ContactModelList.Add(contactModel);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}