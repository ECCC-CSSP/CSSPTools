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
        private async Task<bool> DoMergeJsonWebAllEmails(WebAllEmails webAllEmails, WebAllEmails webAllEmailsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllEmails WebAllEmails, WebAllEmails WebAllEmailsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllEmailsEmailModelList(webAllEmails, webAllEmailsLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllEmailsEmailModelList(WebAllEmails webAllEmails, WebAllEmails webAllEmailsLocal)
        {
            List<EmailModel> emailModelLocalList = (from c in webAllEmailsLocal.EmailModelList
                                                    where c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                    || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                    || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                    select c).ToList();

            foreach (EmailModel emailModelLocal in emailModelLocalList)
            {
                EmailModel emailModelOriginal = webAllEmails.EmailModelList.Where(c => c.TVItemModel.TVItem.TVItemID == emailModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (emailModelOriginal == null)
                {
                    webAllEmails.EmailModelList.Add(emailModelLocal);
                }
                else
                {
                    SyncEmail(emailModelOriginal.Email, emailModelLocal.Email);
                    SyncTVItemModel(emailModelOriginal.TVItemModel, emailModelLocal.TVItemModel);
                }
            }
        }
    }
}
