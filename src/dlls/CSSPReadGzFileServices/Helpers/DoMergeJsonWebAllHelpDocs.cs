/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebAllHelpDocs(WebAllHelpDocs WebAllHelpDocs, WebAllHelpDocs WebAllHelpDocsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllHelpDocs WebAllHelpDocs, WebAllHelpDocs WebAllHelpDocsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            List<HelpDoc> helpDocLocalList = (from c in WebAllHelpDocsLocal.HelpDocList
                                                    where c.DBCommand != DBCommandEnum.Original
                                                    select c).ToList();

            foreach (HelpDoc helpDocLocal in helpDocLocalList)
            {
                HelpDoc helpDocOriginal = WebAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == helpDocLocal.HelpDocID).FirstOrDefault();
                if (helpDocOriginal == null)
                {
                    WebAllHelpDocs.HelpDocList.Add(helpDocLocal);
                }
                else
                {
                    helpDocOriginal = helpDocLocal;
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
