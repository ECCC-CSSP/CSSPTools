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

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
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
                                                        where c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                        || c.Contact.DBCommand != DBCommandEnum.Original
                                                        select c).ToList();

            foreach (ContactModel contactModelLocal in contactModelLocalList)
            {
                ContactModel contactModelOriginal = webAllContacts.ContactModelList.Where(c => c.TVItemModel.TVItem.TVItemID == contactModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (contactModelOriginal == null)
                {
                    webAllContacts.ContactModelList.Add(contactModelLocal);
                }
                else
                {
                    SyncContact(contactModelOriginal.Contact, contactModelLocal.Contact);
                    SyncTVItemModel(contactModelOriginal.TVItemModel, contactModelLocal.TVItemModel);
                }
            }
        }
    }
}
