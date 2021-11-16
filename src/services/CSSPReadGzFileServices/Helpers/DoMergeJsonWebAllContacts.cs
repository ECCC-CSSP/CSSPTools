/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebAllContacts(WebAllContacts webAllContacts, WebAllContacts webAllContactsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllContacts WebAllContacts, WebAllContacts WebAllContactsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllContactsContactModelList(webAllContacts, webAllContactsLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllContactsContactModelList(WebAllContacts webAllContacts, WebAllContacts webAllContactsLocal)
        {
            List<ContactModel> contactModelLocalList = (from c in webAllContactsLocal.ContactModelList
                                                        where c.Contact.DBCommand != DBCommandEnum.Original
                                                        select c).ToList();

            foreach (ContactModel contactModelLocal in contactModelLocalList)
            {
                ContactModel contactModelOriginal = webAllContacts.ContactModelList.Where(c => c.Contact.ContactID == contactModelLocal.Contact.ContactID).FirstOrDefault();
                if (contactModelOriginal == null)
                {
                    webAllContacts.ContactModelList.Add(contactModelLocal);
                }
                else
                {
                    contactModelOriginal.Contact = contactModelLocal.Contact;
                }
            }
        }
    }
}
