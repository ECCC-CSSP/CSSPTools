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

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
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
            List<Email> emailLocalList = (from c in webAllEmailsLocal.EmailList
                                                    where c.DBCommand != DBCommandEnum.Original
                                                    select c).ToList();

            foreach (Email emailLocal in emailLocalList)
            {
                Email emailOriginal = webAllEmails.EmailList.Where(c => c.EmailID == emailLocal.EmailID).FirstOrDefault();
                if (emailOriginal == null)
                {
                    webAllEmails.EmailList.Add(emailLocal);
                }
                else
                {
                    emailOriginal = emailLocal;
                }
            }
        }
    }
}
