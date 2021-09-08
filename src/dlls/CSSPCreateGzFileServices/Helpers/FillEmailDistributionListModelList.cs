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
using System.Reflection;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> FillEmailDistributionListModelList(List<EmailDistributionListModel> EmailDistributionListModelList, TVItem TVItem)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<EmailDistributionListModel> EmailDistributionListModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
            await CSSPLogService.FunctionLog(FunctionName);

            List<EmailDistributionList> EmailDistributionListList = await GetEmailDistributionListListUnderCountry(TVItem);
            List<EmailDistributionListLanguage> EmailDistributionListLanguageList = await GetEmailDistributionListLanguageListUnderCountry(TVItem);
            List<EmailDistributionListContact> EmailDistributionListContactList = await GetEmailDistributionListContactListUnderCountry(TVItem);
            List<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageList = await GetEmailDistributionListContactLanguageListUnderCountry(TVItem);

            foreach (EmailDistributionList emailDistributionList in EmailDistributionListList)
            {
                List<EmailDistributionListContactModel> emailDistributionListContactModelList = new List<EmailDistributionListContactModel>();

                List<EmailDistributionListContact> emailDistributionListContactList = EmailDistributionListContactList.Where(c => c.EmailDistributionListID == emailDistributionList.EmailDistributionListID).ToList();
                foreach (EmailDistributionListContact emailDistributionListContact in emailDistributionListContactList)
                {
                    emailDistributionListContactModelList.Add(new EmailDistributionListContactModel()
                    {
                        EmailDistributionListContact = emailDistributionListContact,
                        EmailDistributionListContactLanguageList = EmailDistributionListContactLanguageList.Where(c => c.EmailDistributionListContactID == emailDistributionListContact.EmailDistributionListContactID).ToList(),
                    });
                }

                EmailDistributionListModelList.Add(new EmailDistributionListModel()
                {
                    EmailDistributionList = emailDistributionList,
                    EmailDistributionListLanguageList = EmailDistributionListLanguageList.Where(c => c.EmailDistributionListID == emailDistributionList.EmailDistributionListID).ToList(),
                    EmailDistributionListContactModelList = emailDistributionListContactModelList,
                }); ;
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}