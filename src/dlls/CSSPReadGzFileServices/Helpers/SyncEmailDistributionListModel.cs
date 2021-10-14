/*
 * Manually edited
 * 
 */
using CSSPDBModels;
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
        private void SyncEmailDistributionListModel(EmailDistributionListModel emailDistributionListModelOriginal, EmailDistributionListModel emailDistributionListModelLocal)
        {
            if (emailDistributionListModelLocal != null)
            {
                if (emailDistributionListModelLocal.EmailDistributionList != null)
                {
                    emailDistributionListModelOriginal.EmailDistributionList = emailDistributionListModelLocal.EmailDistributionList;
                }

                if (emailDistributionListModelLocal.EmailDistributionListLanguageList != null)
                {
                    emailDistributionListModelOriginal.EmailDistributionListLanguageList = emailDistributionListModelLocal.EmailDistributionListLanguageList;
                }

                foreach (EmailDistributionListContactModel emailDistributionListContactModelLocal in emailDistributionListModelLocal.EmailDistributionListContactModelList)
                {
                    EmailDistributionListContactModel emailDistributionListContactModelOriginal = emailDistributionListModelOriginal.EmailDistributionListContactModelList.Where(c => c.EmailDistributionListContact.EmailDistributionListContactID == emailDistributionListContactModelLocal.EmailDistributionListContact.EmailDistributionListContactID).FirstOrDefault();

                    if (emailDistributionListContactModelLocal.EmailDistributionListContact != null)
                    {
                        emailDistributionListContactModelOriginal.EmailDistributionListContact = emailDistributionListContactModelLocal.EmailDistributionListContact;
                    }
                    if (emailDistributionListContactModelLocal.EmailDistributionListContactLanguageList != null)
                    {
                        emailDistributionListContactModelOriginal.EmailDistributionListContactLanguageList = emailDistributionListContactModelLocal.EmailDistributionListContactLanguageList;
                    }
                }
            }
        }
    }
}
