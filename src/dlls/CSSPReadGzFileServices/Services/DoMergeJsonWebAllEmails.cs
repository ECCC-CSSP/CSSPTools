/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllEmails(WebAllEmails WebAllEmails, WebAllEmails WebAllEmailsLocal)
        {
            List<EmailModel> emailModelLocalList = (from c in WebAllEmailsLocal.EmailModelList
                                                        where c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                        || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                        select c).ToList();

            foreach (EmailModel emailModelLocal in emailModelLocalList)
            {
                EmailModel emailModelOriginal = WebAllEmails.EmailModelList.Where(c => c.TVItemModel.TVItem.TVItemID == emailModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (emailModelOriginal == null)
                {
                    WebAllEmails.EmailModelList.Add(emailModelLocal);
                }
                else
                {
                    emailModelOriginal = emailModelLocal;
                }
            }
        }
    }
}
