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

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> FillAllContactModelList(List<ContactModel> ContactModelList)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<ContactModel> ContactModelList)";
            CSSPLogService.FunctionLog(FunctionName);

            List<Contact> ContactList = await GetAllContact();
            List<Email> EmailList = await GetAllEmail();
            List<Tel> TelList = await GetAllTel();
            List<Address> AddressList = await GetAllAddress();

            List<TVItemLink> TVItemLinkContactEmailList = await GetAllTVItemLink(TVTypeEnum.Contact, TVTypeEnum.Email);
            List<TVItemLink> TVItemLinkContactTelList = await GetAllTVItemLink(TVTypeEnum.Contact, TVTypeEnum.Tel);
            List<TVItemLink> TVItemLinkContactAddressList = await GetAllTVItemLink(TVTypeEnum.Contact, TVTypeEnum.Address);

            foreach (Contact contact in ContactList)
            {
                ContactModel contactModel = new ContactModel();
                contactModel.Contact = ContactList.Where(c => c.ContactTVItemID == contact.ContactTVItemID).FirstOrDefault();

                contactModel.ContactEmailTVItemIDList = (from c in TVItemLinkContactEmailList
                                                         where c.FromTVItemID == contact.ContactTVItemID
                                                         select c.ToTVItemID).ToList();

                contactModel.ContactTelTVItemIDList = (from c in TVItemLinkContactTelList
                                                       where c.FromTVItemID == contact.ContactTVItemID
                                                       select c.ToTVItemID).ToList();

                contactModel.ContactAddressTVItemIDList = (from c in TVItemLinkContactAddressList
                                                           where c.FromTVItemID == contact.ContactTVItemID
                                                           select c.ToTVItemID).ToList();

                ContactModelList.Add(contactModel);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}