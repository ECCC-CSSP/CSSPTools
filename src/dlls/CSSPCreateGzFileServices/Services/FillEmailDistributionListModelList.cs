﻿/*
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
        private async Task FillEmailDistributionListModelList(List<EmailDistributionListModel> EmailDistributionListModelList, TVItem TVItem)
        {
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
        }
    }
}